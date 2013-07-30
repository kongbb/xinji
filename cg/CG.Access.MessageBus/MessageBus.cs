using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CG.Access.MessageBus.Components;
using CG.Access.MessageBus.Interfaces;
using CG.Access.MessageBus.Message;
using EasyNetQ;
using EasyNetQ.Topology;

namespace CG.Access.MessageBus
{
    public class MessageBus<T> : IMessageBus<T> where T : class
    {
        #region Fields

        private bool _disposed;

        #endregion

        #region Properties

        public IMessageBusConfigManager ConfigManager { get; set; }

        public IAdvancedBus RabbitBus { get; set; }

        public IExchange Exchange { get; set; }

        public Dictionary<string, IQueue> Queues { get; set; }

        public MessageBusSerializer Serializer { get; set; }

        public IMessageBusLogger MessageBusLogger { get; set; }

        public MessagePropertyMapper<T> MessagePropertyMapper { get; set; }

        #endregion Properties

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    RabbitBus.Dispose();
                }

                // Indicate that the instance has been disposed.
                _disposed = true;
            }
        }

        #endregion

        #region Public Methods

        public virtual void PublishToExchange(QueueMessage<T> queueMessage,
            Action<QueueMessage<T>> setTransportProperties,  string baseRoutingKey = null)
        {
            MessageBusLogger.LogMessageWhenPublished(queueMessage);

            setTransportProperties(queueMessage);

            using (var channel = RabbitBus.OpenPublishChannel())
            {
                string fullRoutingKey = ConfigManager.GetMainRoutingKey(baseRoutingKey);

                channel.Publish(Exchange, fullRoutingKey, 
                    new Message<QueueMessage<T>>(queueMessage));
            }
        }

        public virtual void PublishToExchangeWithProperties(QueueMessage<T> queueMessage,
            Action<QueueMessage<T>> setTransportProperties, string baseRoutingKey = null)
        {
            MessageBusLogger.LogMessageWhenPublished(queueMessage);

            setTransportProperties(queueMessage);

            using (var channel = RabbitBus.OpenPublishChannel())
            {
                var messageBody = Serializer.MessageToBytes(queueMessage);
                var messageProperties = MessagePropertyMapper.MapFromWngType(queueMessage);
                string fullRoutingKey = ConfigManager.GetMainRoutingKey(baseRoutingKey);

                channel.Publish(Exchange, fullRoutingKey, messageProperties, messageBody);
            }
        }

        public virtual void SubscribeToQueue(string baseQueueName,
            Func<QueueMessage<T>, Task> onMessageReceived)
        {
            if (Queues.ContainsKey(baseQueueName))
            {
                RabbitBus.Subscribe<QueueMessage<T>>(Queues[baseQueueName], (msg, messageReceivedInfo) =>
                {
                    MessagePropertyMapper.MapToWngType(msg, messageReceivedInfo);

                    if (ConfigManager.SubscriberShouldLogMessageDetails)
                    {
                         MessageBusLogger.LogMessageWhenConsumed(msg.Properties, messageReceivedInfo);
                    }

                    return onMessageReceived(msg.Body);
                });

                return;
            }

            throw new ApplicationException(
                String.Format(@"Queue with the name {0} 
                    does not exist on this message bus", baseQueueName));
        }

        #endregion Public Methods
    }
}