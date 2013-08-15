using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.MessageBus.Components;
using CG.Access.MessageBus.Interfaces;
using CG.Access.MessageBus.Message;
using CG.Common.Constants;
using CG.Common.Enums;
using CG.Common.Helpers;
using CG.Logic.Domain.OrderPrinting;

namespace CG.Access.MessageBus.Clients
{
    public class OrderPrintingMessageBusClient : IMessageBusClient
    {
        #region Fields

        private const int QueueMessageTimeToLiveInMinutes = 60 * 23;
        private readonly IMessageBus<OrderPrintingMessage> _messageBus;
        private bool _disposed;

        #endregion

        #region Constructor

        public OrderPrintingMessageBusClient(
            IMessageBusFactory<OrderPrintingMessage> messageBusFactory)
        {
            var configManager = new MessageBusConfigManager(
                MessageBusPurposeNames.OrderPrinting,
                ParameterHelper.MessageBusHostAddress);

            
            configManager.UserNameForConnection = ParameterHelper.MessageBusUserName;
            configManager.PasswordForConnection = ParameterHelper.MessageBusPassword;

            configManager.ExchangeType = MessageBusExchangeType.Topic;
            configManager.PerQueueMessageTimeToLiveInMinutes = QueueMessageTimeToLiveInMinutes;
            configManager.QueueBindingPrefix = ParameterHelper.MessageBusQueueBindingPrefix;
            configManager.SubscriberShouldLogMessageDetails = true;

            configManager.QueueBindings.Add(new MessageBusQueueBinding(
                MessageBusQueueNames.OrderSubmitted, 
                MessageBusRoutingKeys.OrderSubmitted)); 

            _messageBus = messageBusFactory.Create(configManager, 
                new MessageBusLogger());
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _messageBus.Dispose();
                }

                // Indicate that the instance has been disposed.
                _disposed = true;
            }
        }

        #endregion

        #region Methods

        public void Publish(QueueMessage<OrderPrintingMessage> queueMessage)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(Func<QueueMessage<OrderPrintingMessage>, Task> onMessageReceived)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
