using System;
using CG.Access.MessageBus.Interfaces;
using CG.Access.MessageBus.Message;
using EasyNetQ;
using MessageReceivedInfo = EasyNetQ.MessageReceivedInfo;

namespace CG.Access.MessageBus.Components
{
    public class MessageBusNullLogger : IMessageBusLogger, IEasyNetQLogger
    {
        public void LogMessageWhenPublished<T>(QueueMessage<T> queueMessage) where T : class
        {            
        }

        public void LogMessageWhenConsumed(MessageProperties properties, 
            MessageReceivedInfo messageReceivedInfo)
        {
        }

        public void DebugWrite(string format, params object[] args)
        {
        }

        public void InfoWrite(string format, params object[] args)
        {
        }

        public void ErrorWrite(string format, params object[] args)
        {
        }

        public void ErrorWrite(Exception exception)
        {
        }
    }
}