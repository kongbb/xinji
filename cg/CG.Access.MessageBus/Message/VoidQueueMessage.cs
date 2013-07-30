namespace CG.Access.MessageBus.Message
{
    /// <summary>
    /// A generic message sent or received from a queue, that does not contain
    /// any message content.
    /// </summary>
    /// <typeparam name="T">The type of the content encapsulated in this message</typeparam>
    public class VoidQueueMessage<T> : BaseQueueMessage<T> where T : class
    {
    }
}