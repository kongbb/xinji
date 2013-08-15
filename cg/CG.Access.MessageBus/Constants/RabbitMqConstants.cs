using CG.Common.Enums;

namespace CG.Access.MessageBus.Constants
{
    public static class RabbitMqConstants
    {
        public const string ArgumentsKeyForDeadLetterExchangeName = "x-dead-letter-exchange";
        public const string ArgumentsKeyForDeadLetterExchangeRoutingKey = "x-dead-letter-routing-key";
        public const string ArgumentsKeyForPerQueueMessageTimeToLive = "x-message-ttl";

        public const string HeadersKeyForRetryLimit = "error-retry-count";

        public const string ExchangePrefix = "Wng";
        public const string ErrorExchangeAndQueueNameSuffix = "Error";
        public const string DeadLetterExchangeAndQueueNameSuffix = "Dead";

        public const string DefaultQueueBindingPrefix = "Wng";

        public const MessageBusExchangeType DefaultExchangeType = MessageBusExchangeType.Direct;

        public const int DefaultPerQueueMessageTimeToLiveInMinutes = 10;
        public const string DefaultVirtualHost = "/";
        public const ushort DefaultHostPort = 5672;
        public const ushort DefaultRequestedHeartbeatInMinutes = 0;
        public const string DefaultUserNameForConnection = "guest";
        public const string DefaultPasswordForConnection = "guest";
    }
}