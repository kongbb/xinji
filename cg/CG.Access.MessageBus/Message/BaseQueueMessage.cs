namespace CG.Access.MessageBus.Message
{
    /// <summary>
    /// Base class for all messages sent or received
    /// from a queue.
    /// </summary>
    public abstract class BaseQueueMessage<T> where T : class
    {
        protected BaseQueueMessage()
        {
            TransportProperties = new MessageTransportProperties<T>();
            ReceivedInfo = new MessageReceivedInfo();
        }

        public MessageTransportProperties<T> TransportProperties { get; set; }

        public MessageReceivedInfo ReceivedInfo { get; set; }
    }
}