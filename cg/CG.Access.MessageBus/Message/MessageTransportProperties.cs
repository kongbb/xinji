using System;
using System.Collections;

namespace CG.Access.MessageBus.Message
{
    /// <summary>
    /// Metadata properties of a message that are independent of its message content
    /// and relate to its transport on the message bus.
    /// </summary>
    public class MessageTransportProperties<T> where T : class
    {
        public MessageTransportProperties()
        {
            AppId = null;
            ContentEncoding = null;
            ContentType = null;
            ReplyTo = null;
            ClusterId = null;
            CorrelationId = Guid.NewGuid().ToString();
            DeliveryMode = 0;
            Expiration = null;
            MessageId = null;
            Priority = 0;
            Timestamp = ConvertToTimestamp(DateTime.UtcNow);
        }

        public string AppId { get; set; }

        public string ClusterId { get; set; }

        public string ContentEncoding { get; set; }

        public string ContentType { get; set; }

        public string CorrelationId { get; set; }

        public byte DeliveryMode { get; set; }

        public string Expiration { get; set; }

        public IDictionary Headers { get; set; }

        public string MessageId { get; set; }

        public byte Priority { get; set; }

        public string ReplyTo { get; set; }

        public long Timestamp { get; set; }

        public string Type
        {
            // Copy of method used by EasyNetQ
            get
            {
                return typeof(QueueMessage<T>).FullName.Replace('.', '_') + ":" +
                    typeof(QueueMessage<T>).Assembly.GetName().Name.Replace('.', '_');
            }
        }

        #region Private Methods

        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private static long ConvertToTimestamp(DateTime value)
        {
            TimeSpan elapsedTime = value - Epoch;
            return (long)elapsedTime.TotalSeconds;
        }

        #endregion
    }
}