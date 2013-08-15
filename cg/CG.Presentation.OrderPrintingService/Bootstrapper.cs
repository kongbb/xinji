using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace CG.Presentation.OrderPrintingService
{
    public static class Bootstrapper
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main()
        {
            HostFactory.Run(x =>
            {
                AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

                x.Service<Processor>(s =>
                {
                    s.ConstructUsing(name => new Processor());
                    s.WhenStarted(p => p.Start());
                    s.WhenStopped(p => p.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription("Process order printing messages.");
            });
        }
    }
}
