using System.Collections;
using EasyNetQ;

namespace CG.Access.MessageBus.Message
{
    /// <summary>
    /// Transform properties to and from WNG defined message types
    /// and EasyNetQ types.
    /// </summary>
    public class MessagePropertyMapper<T> where T : class
    {
        // Extract requested transport properties passed in from the WNG type into the EasyNetQ MessageProperties type.
        public MessageProperties MapFromWngType(QueueMessage<T> queueMessage)
        {
            var easyNetqProperties = new MessageProperties();

            // Must set each property only if initialised, since EasyNetQProperties have property setters that 
            // record whether the property is ever Set (e.g. private variables 'isContentTypePresent') and once
            // set (even if not set to null value) we won't get the default RabbitMQClient properties which
            // can cause Null Reference Exceptions

            if (queueMessage.TransportProperties.AppId != null)
            {
                easyNetqProperties.AppId = queueMessage.TransportProperties.AppId;
            }

            if (queueMessage.TransportProperties.ClusterId != null)
            {
                easyNetqProperties.ClusterId = queueMessage.TransportProperties.ClusterId;
            }

            if (queueMessage.TransportProperties.ContentEncoding != null)
            {
                easyNetqProperties.ContentEncoding = queueMessage.TransportProperties.ContentEncoding;
            }

            if (queueMessage.TransportProperties.ContentType != null)
            {
                easyNetqProperties.ContentType = queueMessage.TransportProperties.ContentType;
            }

            if (queueMessage.TransportProperties.CorrelationId != null)
            {
                easyNetqProperties.CorrelationId = queueMessage.TransportProperties.CorrelationId;
            }

            if (queueMessage.TransportProperties.DeliveryMode != default(byte))
            {
                easyNetqProperties.DeliveryMode = queueMessage.TransportProperties.DeliveryMode;
            }

            if (queueMessage.TransportProperties.Expiration != null)
            {
                easyNetqProperties.Expiration = queueMessage.TransportProperties.Expiration;
            }

            if ((queueMessage.TransportProperties.Headers != null) && (queueMessage.TransportProperties.Headers.Count > 0))
            {
                easyNetqProperties.Headers = new Hashtable(queueMessage.TransportProperties.Headers);
            }

            if (queueMessage.TransportProperties.MessageId != null)
            {
                easyNetqProperties.MessageId = queueMessage.TransportProperties.MessageId;
            }

            if (queueMessage.TransportProperties.Priority != default(byte))
            {
                easyNetqProperties.Priority = queueMessage.TransportProperties.Priority;
            }

            if (queueMessage.TransportProperties.ReplyTo != null)
            {
                easyNetqProperties.ReplyTo = queueMessage.TransportProperties.ReplyTo;
            }

            if (queueMessage.TransportProperties.Timestamp != default(long))
            {
                easyNetqProperties.Timestamp = queueMessage.TransportProperties.Timestamp;
            }

            if (queueMessage.TransportProperties.Type != null)
            {
                easyNetqProperties.Type = queueMessage.TransportProperties.Type;
            }

            return easyNetqProperties;
        }

        // Extract transport message properties and received info from the third party message type 
        // (EasyNetQ) and copy into WNG defined message type.
        public void MapToWngType(IMessage<QueueMessage<T>> msg,
            EasyNetQ.MessageReceivedInfo messageReceivedInfo)
        {
            var messageBody = msg.Body;

            messageBody.TransportProperties.AppId = msg.Properties.AppId;
            messageBody.TransportProperties.ClusterId = msg.Properties.ClusterId;
            messageBody.TransportProperties.ContentEncoding = msg.Properties.ContentEncoding;
            messageBody.TransportProperties.ContentType = msg.Properties.ContentType;
            messageBody.TransportProperties.CorrelationId = msg.Properties.CorrelationId;
            messageBody.TransportProperties.DeliveryMode = msg.Properties.DeliveryMode;
            messageBody.TransportProperties.Expiration = msg.Properties.Expiration;
            messageBody.TransportProperties.MessageId = msg.Properties.MessageId;
            messageBody.TransportProperties.Priority = msg.Properties.Priority;
            messageBody.TransportProperties.ReplyTo = msg.Properties.ReplyTo;
            messageBody.TransportProperties.Timestamp = msg.Properties.Timestamp;

            messageBody.TransportProperties.Headers = new Hashtable(msg.Properties.Headers);

            messageBody.ReceivedInfo.ConsumerTag = messageReceivedInfo.ConsumerTag;
            messageBody.ReceivedInfo.DeliverTag = messageReceivedInfo.DeliverTag;
            messageBody.ReceivedInfo.Exchange = messageReceivedInfo.Exchange;
            messageBody.ReceivedInfo.Redelivered = messageReceivedInfo.Redelivered;
            messageBody.ReceivedInfo.RoutingKey = messageReceivedInfo.RoutingKey;
        }
    }
}