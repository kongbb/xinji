using System;
using CG.Access.MessageBus.Interfaces;
using CG.Access.MessageBus.Message;
using CG.Common.Loggers;
using EasyNetQ;
using Microsoft.Practices.Unity;
using MessageReceivedInfo = EasyNetQ.MessageReceivedInfo;

namespace CG.Access.MessageBus.Components
{
    public class MessageBusLogger : IMessageBusLogger, IEasyNetQLogger
    {
        [Dependency]
        public ILogger Logger { get; set; }

        #region Methods

        public void LogMessageWhenPublished<T>(QueueMessage<T> queueMessage) where T : class
        {
            Logger.Debug(String.Format("Message Published At Local Time {0}", DateTime.Now));
            Logger.Debug(String.Format("\tMessage Correlation ID: {0}",
                queueMessage.TransportProperties.CorrelationId));
            Logger.Debug(String.Format("\tMessage Content Type: {0}",
                queueMessage.MessageContent.GetType()));
        }

        public void LogMessageWhenConsumed(MessageProperties properties,
            MessageReceivedInfo messageReceivedInfo)
        {
            Logger.Debug(String.Format("Message received by subscriber at {0}", DateTime.UtcNow.ToString()));
            Logger.Debug(String.Format("Properties for message with Id: {0}, Correlation Id: {1}",
                properties.MessageId, properties.CorrelationId));

            Logger.Debug(String.Format("\t\tMessage Property: {0}, Value: {1}", "AppId",
                properties.AppId));
            Logger.Debug(String.Format("\t\tMessage Property: {0}, Value: {1}", "ClusterId",
                properties.ClusterId));
            Logger.Debug(String.Format("\t\tMessage Property: {0}, Value: {1}", "ContentEncoding",
                properties.ContentEncoding));
            Logger.Debug(String.Format("\t\tMessage Property: {0}, Value: {1}", "ContentType",
                properties.ContentType));
            Logger.Debug(String.Format("\t\tMessage Property: {0}, Value: {1}", "DeliveryMode",
                properties.DeliveryMode));
            Logger.Debug(String.Format("\t\tMessage Property: {0}, Value: {1}", "Expiration",
                properties.Expiration));
            Logger.Debug(String.Format("\t\tMessage Property: {0}, Value: {1}", "Priority",
                properties.Priority));
            Logger.Debug(String.Format("\t\tMessage Property: {0}, Value: {1}", "ReplyTo",
                properties.ReplyTo));
            Logger.Debug(String.Format("\t\tMessage Property: {0}, Value: {1}", "Timestamp",
                properties.Timestamp));
            Logger.Debug(String.Format("\t\tMessage Property: {0}, Value: {1}", "Type", 
                properties.Type));
            Logger.Debug(String.Format("\t\tMessage Property: {0}, Value: {1}", "UserId",
                properties.UserId));

            foreach (var headerKey in properties.Headers.Keys)
            {
                Logger.Debug(String.Format("\t\t\tMessage Header: {0}, Value: {1}", headerKey,
                    properties.Headers[headerKey]));
            }

            Logger.Debug(String.Format("\t\tMessage Received Info: {0}, Value: {1}", "ConsumerTag",
                messageReceivedInfo.ConsumerTag));
            Logger.Debug(String.Format("\t\tMessage Received Info: {0}, Value: {1}", "DeliverTag",
                messageReceivedInfo.DeliverTag));
            Logger.Debug(String.Format("\t\tMessage Received Info: {0}, Value: {1}", "Exchange",
                messageReceivedInfo.Exchange));
            Logger.Debug(String.Format("\t\tMessage Received Info: {0}, Value: {1}", "Redelivered",
                messageReceivedInfo.Redelivered));
            Logger.Debug(String.Format("\t\tMessage Received Info: {0}, Value: {1}", "RoutingKey",
                messageReceivedInfo.RoutingKey));
        }

        public void DebugWrite(string format, params object[] args)
        {
            // Temporary hack to make queue creation problems more visible in logs until EasyNetQ is 
            // updated as per https://github.com/mikehadlow/EasyNetQ/issues/32

            if (format.ToUpper().StartsWith("MODEL SHUTDOWN FOR QUEUE"))
            {
                Logger.Error("*******************************************************************************");
                Logger.Error("*******************************************************************************");
                Logger.Error("ERROR - QUEUE COULD NOT BE CREATED. PLEASE DELETE EXISTING QUEUES AND TRY AGAIN");
                Logger.Error("*******************************************************************************");
                Logger.Error("*******************************************************************************");
            }

            Logger.Debug(format, args);
        }

        public void InfoWrite(string format, params object[] args)
        {
            Logger.Info(format, args);
        }

        public void ErrorWrite(string format, params object[] args)
        {
            Logger.Error(format, args);
        }

        public void ErrorWrite(Exception exception)
        {
            Logger.Error(exception);
        }

        #endregion Methods
    }
}