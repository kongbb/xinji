using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.MessageBus.Message;
using CG.Logic.Domain.OrderPrinting;

namespace CG.Access.MessageBus.Clients
{
    public class BillPrintingMessageBusClient : IMessageBusClient
    {
        public void Publish(QueueMessage<OrderPrintingMessage> queueMessage)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(Func<QueueMessage<OrderPrintingMessage>, Task> onMessageReceived)
        {
            throw new NotImplementedException();
        }
    }
}
