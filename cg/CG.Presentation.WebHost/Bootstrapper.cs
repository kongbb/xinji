using System.Web.Http;
using CG.Common.Loggers;
using CG.Common.Utility;
using CG.Presentation.WebHost.Helper;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.WebApi;
using NLog;
using UnityHelper = CG.Common.Helpers.UnityHelper;

namespace CG.Presentation.WebHost
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            UnityHelper.Current = container;
            Logger logger = LogManager.GetLogger(typeof(Bootstrapper).ToString());
            logger.Debug("About to start unity configurations.");
            // utility
            container.RegisterType<ILogger, NLoggerAdapter>(new ContainerControlledLifetimeManager());
            container
                .RegisterType<IConfig, AppConfig>(new ContainerControlledLifetimeManager())
                .RegisterType<WebHostConfigurationManager>(new ContainerControlledLifetimeManager());
            
            logger.Debug("Finish unity config.");
            return container;
        }
    }
}