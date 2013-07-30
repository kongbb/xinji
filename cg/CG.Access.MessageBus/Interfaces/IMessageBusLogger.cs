using System;
using CG.Access.MessageBus.Message;
using EasyNetQ;
using MessageReceivedInfo = EasyNetQ.MessageReceivedInfo;

namespace CG.Access.MessageBus.Interfaces
{
    public interface IMessageBusLogger
    {
        void LogMessageWhenPublished<T>(QueueMessage<T> queueMessage) where T : class;

        void LogMessageWhenConsumed(MessageProperties properties,
            MessageReceivedInfo messageReceivedInfo);

        void DebugWrite(string format, params object[] args);

        void InfoWrite(string format, params object[] args);
        
        void ErrorWrite(string format, params object[] args);

        void ErrorWrite(Exception exception);
    }
}