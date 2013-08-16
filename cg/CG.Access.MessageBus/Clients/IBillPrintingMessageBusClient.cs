using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.MessageBus.Message;
using CG.Logic.Domain.BillPrinting;

namespace CG.Access.MessageBus.Clients
{
    public interface IBillPrintingMessageBusClient
    {
        void Publish(QueueMessage<BillPrintingMessage> queueMessage);
        void Subscribe(Func<QueueMessage<BillPrintingMessage>, Task> onMessageReceived);
    }
}
