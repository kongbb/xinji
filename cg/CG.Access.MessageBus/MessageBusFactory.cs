using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CG.Access.MessageBus.Components;
using CG.Access.MessageBus.Constants;
using CG.Access.MessageBus.Interfaces;
using CG.Access.MessageBus.Message;
using CG.Common.Enums;
using CG.Common.Loggers;
using EasyNetQ;
using EasyNetQ.Topology;

namespace CG.Access.MessageBus
{
    public class MessageBusFactory<T> : IMessageBusFactory<T> where T : class
    {
        #region Fields

        private IExchange _deadLetterExchange;
        private bool _shouldBindQueuesWithRoutingKey;

        #endregion

        #region Properties

        protected ILogger Logger { get; private set; }

        #endregion Properties

        #region Constructor

        public MessageBusFactory (ILogger logger)
        {
            Logger = logger;
        }

        #endregion

        #region Public Methods

        public IMessageBus<T> Create(IMessageBusConfigManager configManager,
            IMessageBusLogger messageBusLogger)
        {
            var messageBus = new MessageBus<T>();

            messageBus.MessagePropertyMapper = new MessagePropertyMapper<T>();

            messageBus.MessageBusLogger = messageBusLogger;

            SetAndVerifyConfiguration(messageBus, configManager);

            CreateRabbitBus(messageBus);

            CreateExchanges(messageBus);

            CreateQueues(messageBus);

            return messageBus;
        }

        #endregion

        #region Private Methods

        private void SetAndVerifyConfiguration(MessageBus<T> messageBus, IMessageBusConfigManager configManager)
        {
            if (configManager.QueueBindings.Count < 1)
            {
                throw new ApplicationException(@"At least one queue binding must be
                    supplied to the message bus factory.");
            }

            messageBus.ConfigManager = configManager;
        }

        private void CreateRabbitBus(MessageBus<T> messageBus)
        {
            IMessageBusConfigManager configManager = messageBus.ConfigManager;

            messageBus.MessageBusLogger.DebugWrite("Setting up Message Bus Serializer...");
            messageBus.Serializer = new MessageBusSerializer();

            messageBus.MessageBusLogger.DebugWrite("Creating Message Bus...");

            // Note: not possible to set up 'prefetch' value with the EasyNetQ RabbitHutch
            // overload used below. If prefetch value needs to be used then will need to 
            // construct an AMQP connection string (see EasyNetQ class ConnectionStringGrammar).
            // Current prefetch default in EasyNetQ is 50 which should be OK.

            messageBus.RabbitBus = RabbitHutch.CreateBus(
                configManager.HostAddress,
                configManager.HostPort,
                configManager.VirtualHost,
                configManager.UserNameForConnection,
                configManager.PasswordForConnection,
                configManager.RequestedHeartbeatInMinutes,
                x =>
                {
                    x.Register<ISerializer>(
                        serviceProvider => new MessageBusSerializer());

                    x.Register<IEasyNetQLogger>(serviceProvider => new MessageBusLogger());

                    x.Register<IConsumerErrorStrategy>(
                        serviceProvider => new MessageBusConsumerErrorStrategy(
                            messageBus.ConfigManager.ErrorExchangeName,
                            serviceProvider.Resolve<IConnectionFactory>(),
                            serviceProvider.Resolve<ISerializer>(),
                            serviceProvider.Resolve<IEasyNetQLogger>(),
                            serviceProvider.Resolve<IConventions>()));
                }
                ).Advanced;
        }

        private void CreateExchanges(MessageBus<T> messageBus)
        {
            string mainExchangeName = messageBus.ConfigManager.MainExchangeName;
            string deadLetterExchangeName = messageBus.ConfigManager.DeadLetterExchangeName;

            switch (messageBus.ConfigManager.ExchangeType)
            {
                case MessageBusExchangeType.Direct:
                    Logger.Debug(String.Format("Setting up Direct Exchange with name {0}...", mainExchangeName));
                    messageBus.Exchange = Exchange.DeclareDirect(mainExchangeName);
                    _shouldBindQueuesWithRoutingKey = true;
                    break;

                case MessageBusExchangeType.Topic:
                    Logger.Debug(String.Format("Setting up Topic Exchange with name {0}...", mainExchangeName));
                    messageBus.Exchange = Exchange.DeclareTopic(mainExchangeName);
                    _shouldBindQueuesWithRoutingKey = true;
                    break;

                case MessageBusExchangeType.Fanout:
                    Logger.Debug(String.Format("Setting up Fanout Exchange with name {0}...", mainExchangeName));
                    messageBus.Exchange = Exchange.DeclareFanout(mainExchangeName);
                    _shouldBindQueuesWithRoutingKey = false;
                    break;

                default:
                    throw new ApplicationException("Unknown exchange type found when creating message bus.");
                    break;
            }

            messageBus.MessageBusLogger.DebugWrite("Setting up Dead Letter Exchange with name {0}...",
                deadLetterExchangeName);

            _deadLetterExchange = Exchange.DeclareDirect(deadLetterExchangeName);
        }

        private IDictionary<string, object> GetQueueArguments(MessageBus<T> messageBus, string deadLetterRoutingKey)
        {
            var queueArguments = new Dictionary<string, object>
            {
                {
                    RabbitMqConstants.ArgumentsKeyForPerQueueMessageTimeToLive,
                    messageBus.ConfigManager.PerQueueMessageTimeToLiveInMilliseconds
                },
                {
                    RabbitMqConstants.ArgumentsKeyForDeadLetterExchangeName,
                    messageBus.ConfigManager.DeadLetterExchangeName
                },
                {
                    RabbitMqConstants.ArgumentsKeyForDeadLetterExchangeRoutingKey,
                    deadLetterRoutingKey
                }
            };

            return queueArguments;
        }

        private void CreateQueues(MessageBus<T> messageBus)
        {
            messageBus.Queues = new Dictionary<string, IQueue>();

            using (var temporaryRabbitBusForBootstrapping = RabbitHutch.CreateBus(
                   messageBus.ConfigManager.HostAddress,
                   messageBus.ConfigManager.HostPort,
                   messageBus.ConfigManager.VirtualHost,
                   messageBus.ConfigManager.UserNameForConnection,
                   messageBus.ConfigManager.PasswordForConnection,
                   messageBus.ConfigManager.RequestedHeartbeatInMinutes,
                   x => x.Register<IEasyNetQLogger>(
                       serviceProvider => new MessageBusNullLogger())).Advanced)
            {

                // Attach Queues to the Exchange
                foreach (var queueBinding in messageBus.ConfigManager.QueueBindings)
                {
                    string mainQueueName = messageBus.ConfigManager.GetMainQueueName(queueBinding.BaseQueueName);

                    string deadLetterQueueName =
                        messageBus.ConfigManager.GetDeadLetterQueueName(queueBinding.BaseQueueName);
                    string deadLetterRoutingKey =
                        messageBus.ConfigManager.GetDeadLetterRoutingKey(queueBinding.BaseQueueName);

                    IDictionary<string, object> queueArguments = GetQueueArguments(messageBus,
                        deadLetterRoutingKey);

                    messageBus.MessageBusLogger.DebugWrite("Setting up Queue with name {0}...", mainQueueName);
                    IQueue mainQueue = Queue.DeclareDurable(mainQueueName, queueArguments);

                    if (_shouldBindQueuesWithRoutingKey)
                    {
                        mainQueue.BindTo(messageBus.Exchange,
                            messageBus.ConfigManager.GetMainRoutingKey(queueBinding.BaseRoutingKey));
                    }
                    else
                    {
                        mainQueue.BindTo(messageBus.Exchange);
                    }

                    InitializeQueueWithThrowAwaySubscription(temporaryRabbitBusForBootstrapping,
                        mainQueue);

                    messageBus.Queues.Add(queueBinding.BaseQueueName, mainQueue);

                    // Set up dead letter exchanges and dead letter queues for each original queue
                    messageBus.MessageBusLogger.DebugWrite("Setting up Dead Letter Queue with name {0}...",
                        deadLetterQueueName);

                    IQueue deadLetterQueue =
                        Queue.DeclareDurable(deadLetterQueueName);

                    deadLetterQueue.BindTo(_deadLetterExchange, deadLetterRoutingKey);

                    InitializeQueueWithThrowAwaySubscription(temporaryRabbitBusForBootstrapping,
                        deadLetterQueue);
                }
            }
        }

        private void InitializeQueueWithThrowAwaySubscription(IAdvancedBus rabbitBus, IQueue queue)
        {
            rabbitBus.Subscribe<QueueMessage<T>>(queue,
                (msg, messageReceivedInfo) => Task.Factory.StartNew(() => { }));
        }

        #endregion
    }
}