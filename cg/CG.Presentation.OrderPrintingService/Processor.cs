using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.MessageBus.Clients;
using Microsoft.Practices.Unity;
using NLog;

namespace CG.Presentation.OrderPrintingService
{
    public class Processor
    {
        #region Properties

        private Logger Logger
        {
            get
            {
                return LogManager.GetLogger(GetType().Name);
            }
        }

        [Dependency]
        private IMessageBusClient OrderPrintingMessageBusClient { get; set; }

        #endregion

        public void Start()
        {
            try
            {
                PrintOrders();
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Could not initialize OrderPrinting Processor", ex);
                throw;
            }
        }

        public void Stop()
        {
            //UnityHelper.DestroyDefaultContainer();
        }

        private void PrintOrders()
        {
            Logger.Info("About to subscribe to (completed) claim submissions Message Bus.");

            OrderPrintingMessageBusClient.Subscribe(msg =>
                Task.Factory.StartNew(() =>
                {
                    Logger.Info(
                        String.Format("About to printing order."));

                    

                    //if (responseDto.IsSuccessful)
                    //{
                        Logger.Info(
                            String.Format("Completed printing order"));

                        //UpdateClaimOnSuccessfulRegistration(responseDto.Payload);
                    //}
                }));
        }
    }
}
