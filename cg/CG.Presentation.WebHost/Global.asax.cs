using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CG.Presentation.WebHost.Helper;
using Microsoft.Practices.Unity;
using NLog;

namespace CG.Presentation.WebHost
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //InitUnityAndRegisterTypes();
            //ControllerBuilder.Current.SetControllerFactory(typeof(ControllerFactory));
            LogManager.GetLogger(GetType().ToString()).Debug("Application Start");
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void InitUnityAndRegisterTypes()
        {
            UnityHelper.Container = new UnityContainer()
              .RegisterTypes(AllClasses.FromLoadedAssemblies(),
                            WithMappings.FromMatchingInterface,
                            WithName.Default,
                            WithLifetime.ContainerControlled);
            //.RegisterType<Business.IBusinessClass, Business.BusinessClass>()
            //.RegisterType<Business.IDoSomething, Business.DoSomething>();
        }
    }
}