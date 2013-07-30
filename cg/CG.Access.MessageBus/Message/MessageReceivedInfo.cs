namespace CG.Access.MessageBus.Message
{
    /// <summary>
    /// Metadata properties about the receipt of a message by the consumer.
    /// </summary>
    public class MessageReceivedInfo
    {
        public string ConsumerTag { get; set; }

        public ulong DeliverTag { get; set; }

        public string Exchange { get; set; }

        public bool Redelivered { get; set; }

        public string RoutingKey { get; set; }
    }
}