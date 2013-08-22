using System.Web.Http;
using CG.Common.Loggers;
using CG.Common.Utility;
using CG.Presentation.WebHost.Helper;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.WebApi;
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

            // utility
            container.RegisterType<ILogger, NLoggerAdapter>(new ContainerControlledLifetimeManager());
            container
                .RegisterType<WebHostConfigurationManager>(new ContainerControlledLifetimeManager())
                .RegisterType<IConfig, AppConfig>(new ContainerControlledLifetimeManager());
            
            return container;
        }
    }
}