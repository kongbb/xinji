using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CG.Access.DataAccess.Repositories;
using CG.Access.DataAccess.RepositoryInterface;
using CG.Logic.Service.Interface;
using CG.Logic.Service.Service;
using CG.Presentation.WebApi.Controllers;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.WebApi;

namespace CG.Presentation.WebApi
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

            container
                .RegisterType<TestApiController>()
                .RegisterType<ITestService, TestService>()
                .RegisterType<ITestRepository, TestRepository>();

            return container;
        }
    }
}