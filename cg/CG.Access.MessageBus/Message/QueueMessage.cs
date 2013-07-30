namespace CG.Access.MessageBus.Message
{
    /// <summary>
    /// A generic message sent or received from a queue, and contains
    /// a message content object as well as metadata about the message.
    /// </summary>
    /// <typeparam name="T">The type of the content encapsulated in this message</typeparam>
    public class QueueMessage<T> : BaseQueueMessage<T> where T : class
    {
        /// <summary>
        /// The content contained in this message.
        /// </summary>
        public T MessageContent { get; set; }
    }
}