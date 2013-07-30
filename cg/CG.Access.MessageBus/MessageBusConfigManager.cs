using System;
using System.Collections.Generic;
using CG.Access.MessageBus.Components;
using CG.Access.MessageBus.Constants;
using CG.Access.MessageBus.Interfaces;

namespace CG.Access.MessageBus
{
    public class MessageBusConfigManager : IMessageBusConfigManager
    {
        #region Fields

        private const int SecondsPerMinute = 60;
        private const int MillisecondsPerSecond = 1000;

        private readonly string _messageBusPurpose;
        private readonly string _hostAddress;

        #endregion Fields

        #region Constructor

        public MessageBusConfigManager(string messageBusPurpose, string hostAddress)
        {
            if (String.IsNullOrWhiteSpace(messageBusPurpose))
            {
                throw new ArgumentNullException("messageBusPurpose",
                    "A message bus must be initialised with a purpose name.");
            }

            _messageBusPurpose = messageBusPurpose;

            if (String.IsNullOrWhiteSpace(hostAddress))
            {
                throw new ArgumentNullException("hostAddress",
                    "A message bus must be initialised with a host IP address.");
            }

            _hostAddress = hostAddress;

            HostPort = RabbitMqConstants.DefaultHostPort;

            VirtualHost = RabbitMqConstants.DefaultVirtualHost;

            UserNameForConnection = RabbitMqConstants.DefaultUserNameForConnection;

            PasswordForConnection = RabbitMqConstants.DefaultPasswordForConnection;

            RequestedHeartbeatInMinutes = RabbitMqConstants.DefaultRequestedHeartbeatInMinutes;

            ExchangeType = RabbitMqConstants.DefaultExchangeType;

            PerQueueMessageTimeToLiveInMinutes = 
                RabbitMqConstants.DefaultPerQueueMessageTimeToLiveInMinutes;

            SubscriberShouldLogMessageDetails = false;

            QueueBindings = new List<MessageBusQueueBinding>();

            QueueBindingPrefix = RabbitMqConstants.DefaultQueueBindingPrefix;
        }

        #endregion Constructor

        #region Properties


        public string HostAddress
        {
            get { return _hostAddress; }
        }

        public ushort HostPort { get; set; }

        public string VirtualHost { get; set; }

        public string UserNameForConnection { get; set; }

        public string PasswordForConnection { get; set; }

        public ushort RequestedHeartbeatInMinutes { get; set; }

        public MessageBusExchangeType ExchangeType { get; set; }

        public bool SubscriberShouldLogMessageDetails { get; set; }

        public string QueueBindingPrefix { get; set; }
        
        public int PerQueueMessageTimeToLiveInMinutes { get; set; }

        public int PerQueueMessageTimeToLiveInMilliseconds
        {
            get
            {
                if (PerQueueMessageTimeToLiveInMinutes < 0)
                {
                    throw new ApplicationException(@"Time to live must not be
                        less than zero");
                }

                if (PerQueueMessageTimeToLiveInMinutes >= 35791)
                {
                    throw new ApplicationException(@"Time to live in minutes must not result
                        in a millisecond value greater than 2,147,483,647.");
                }

                return PerQueueMessageTimeToLiveInMinutes 
                    * SecondsPerMinute * MillisecondsPerSecond;
            }
        }

        public string MainExchangeName
        {
            get
            {
                return RabbitMqConstants.ExchangePrefix + "_"
                    + ParameterHelper.Environment + "_" + _messageBusPurpose;
            }
        }

        public string DeadLetterExchangeName
        {
            get
            {
                return RabbitMqConstants.ExchangePrefix + "_"
                    + ParameterHelper.Environment + "_" + _messageBusPurpose 
                    + "_" + RabbitMqConstants.DeadLetterExchangeAndQueueNameSuffix;
            }
        }

        public string ErrorExchangeName
        {
            get
            {
                return RabbitMqConstants.ExchangePrefix + "_"
                    + ParameterHelper.Environment + "_" + _messageBusPurpose 
                    + "_" + RabbitMqConstants.ErrorExchangeAndQueueNameSuffix;
            }
        }

        public List<MessageBusQueueBinding> QueueBindings { get; set; }

        #endregion Properties

        #region Public Methods

        public string GetMainQueueName(string baseQueueName)
        {
            return QueueBindingPrefix + "_" + baseQueueName;
        }

        public string GetMainRoutingKey(string baseRoutingKey)
        { 
            return QueueBindingPrefix + "." + baseRoutingKey;
        }

        public string GetErrorQueueName(string baseQueueName)
        {
            // Each queue has a matching error queue (one-to-one mapping).
            return GetMainQueueName(baseQueueName) + "_" 
                + RabbitMqConstants.ErrorExchangeAndQueueNameSuffix;
        }

        public string GetErrorRoutingKey(string baseQueueName)
        {
            // Routing key should route messages one-to-one from the original queue to a matching error
            // queue, hence use the queue name as the basis for the routing key.
            return GetMainQueueName(baseQueueName) + "_" 
                + RabbitMqConstants.ErrorExchangeAndQueueNameSuffix;
        }

        public string GetDeadLetterQueueName(string baseQueueName)
        {
            // Each queue has a matching dead letter queue (one-to-one mapping).
            return GetMainQueueName(baseQueueName) 
                + "_" + RabbitMqConstants.DeadLetterExchangeAndQueueNameSuffix;
        }

        public string GetDeadLetterRoutingKey(string baseQueueName)
        {
            // Routing key should route messages one-to-one from the original queue to a matching dead letter
            // queue, hence use the queue name as the basis for the routing key.
            return GetMainQueueName(baseQueueName) 
                + "_" + RabbitMqConstants.DeadLetterExchangeAndQueueNameSuffix;
        }

        #endregion Public Methods
    }
}