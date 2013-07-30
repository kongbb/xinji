using System;
using System.Threading.Tasks;
using CG.Access.MessageBus.Message;

namespace CG.Access.MessageBus.Interfaces
{
    public interface IMessageBus<T> : IDisposable where T : class
    {
        void PublishToExchange(QueueMessage<T> queueMessage, 
            Action<QueueMessage<T>> setTransportProperties, string baseRoutingKey);

        void PublishToExchangeWithProperties(QueueMessage<T> queueMessage, 
            Action<QueueMessage<T>> setTransportProperties, string baseRoutingKey);

        void SubscribeToQueue(string baseQueueName, 
            Func<QueueMessage<T>, Task> onMessageReceived);
    }
}
