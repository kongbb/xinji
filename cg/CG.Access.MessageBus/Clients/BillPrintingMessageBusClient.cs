using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.MessageBus.Message;
using CG.Logic.Domain.BillPrinting;

namespace CG.Access.MessageBus.Clients
{
    public class BillPrintingMessageBusClient : IBillPrintingMessageBusClient
    {
        public void Publish(QueueMessage<BillPrintingMessage> queueMessage)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(Func<QueueMessage<BillPrintingMessage>, Task> onMessageReceived)
        {
            throw new NotImplementedException();
        }
    }
}
