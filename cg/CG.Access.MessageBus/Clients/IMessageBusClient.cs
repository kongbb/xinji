using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.MessageBus.Message;
using CG.Logic.Domain.OrderPrinting;

namespace CG.Access.MessageBus.Clients
{
    public interface IMessageBusClient
    {
        void Publish(QueueMessage<OrderPrintingMessage> queueMessage);
        void Subscribe(Func<QueueMessage<OrderPrintingMessage>, Task> onMessageReceived);
    }
}
