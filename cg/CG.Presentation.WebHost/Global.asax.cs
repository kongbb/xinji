using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CG.Common.Loggers;
using CG.Presentation.WebHost.Helper;
using Microsoft.Practices.Unity;
using NLog;

namespace CG.Presentation.WebHost
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private ILogger Logger { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Bootstrapper.Initialise();

            Logger = Common.Helpers.UnityHelper.Current.Resolve<ILogger>();

            Logger.Debug("Initilization finished. Application Start");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Logger.Error(ex);
        }
    }
}