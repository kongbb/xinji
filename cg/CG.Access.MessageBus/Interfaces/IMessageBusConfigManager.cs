using System.Collections.Generic;
using CG.Access.MessageBus.Components;
using CG.Common.Enums;

namespace CG.Access.MessageBus.Interfaces
{
    public interface IMessageBusConfigManager
    {
        string HostAddress { get; }

        ushort HostPort { get; set; }

        string VirtualHost { get; set; }

        string UserNameForConnection { get; set; }

        string PasswordForConnection { get; set; }

        ushort RequestedHeartbeatInMinutes { get; set; }

        int PerQueueMessageTimeToLiveInMilliseconds { get;  }

        MessageBusExchangeType ExchangeType { get; set; }

        bool SubscriberShouldLogMessageDetails { get; set; }
        
        string QueueBindingPrefix { get; set; }

        string MainExchangeName { get; }

        string GetMainQueueName(string baseQueueName);

        string GetMainRoutingKey(string baseRoutingKey);

        string ErrorExchangeName { get; }

        string GetErrorQueueName(string baseQueueName);

        string GetErrorRoutingKey(string baseQueueName);

        string DeadLetterExchangeName { get; }
        
        string GetDeadLetterQueueName(string baseQueueName);

        string GetDeadLetterRoutingKey(string baseQueueName);

        List<MessageBusQueueBinding> QueueBindings { get; set; }
    }
}