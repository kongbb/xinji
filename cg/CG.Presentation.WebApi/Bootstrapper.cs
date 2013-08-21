﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CG.Access.DataAccess;
using CG.Access.DataAccess.Repositories;
using CG.Access.DataAccess.RepositoryInterface;
using CG.Access.MessageBus;
using CG.Access.MessageBus.Clients;
using CG.Access.MessageBus.Components;
using CG.Access.MessageBus.Interfaces;
using CG.Common.Helpers;
using CG.Common.Loggers;
using CG.Logic.Domain.OrderPrinting;
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
            UnityHelper.Current = container;

            // utility
            container.RegisterType<ILogger, NLoggerAdapter>(new ContainerControlledLifetimeManager());

            // DBContext
            container.RegisterType<CGEntities>();

            // UserRepository
            container.RegisterType<IUserRepository, UserRepository>();

            // controller, service, repository
            container
                .RegisterType<TestApiController>()
                .RegisterType<ITestService, TestService>()
                .RegisterType<ITestRepository, TestRepository>(new ContainerControlledLifetimeManager());
            
            // message bus
            container
                .RegisterType<MessageBusLogger>(new ContainerControlledLifetimeManager())
                // order printing
                .RegisterType<IOrderPrintingMessageBusClient, OrderPrintingMessageBusClient>(new ContainerControlledLifetimeManager())
                .RegisterType<IMessageBusFactory<OrderPrintingMessage>,MessageBusFactory<OrderPrintingMessage>>(new ContainerControlledLifetimeManager())
                // bill printing
                .RegisterType<IBillPrintingMessageBusClient, BillPrintingMessageBusClient>(new ContainerControlledLifetimeManager());

            return container;
        }
    }
}