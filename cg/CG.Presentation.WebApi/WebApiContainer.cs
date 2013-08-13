using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;

namespace CG.Presentation.WebApi
{
    class WebApiContainer : IDependencyScope
    {
        protected IUnityContainer Container { get; set; }

        public WebApiContainer(IUnityContainer container)
        {
            Container = container;
        }

        public void Dispose()
        {
            Container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            if (Container.IsRegistered(serviceType))
            {
                return Container.Resolve(serviceType);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (Container.IsRegistered(serviceType))
            {
                return Container.ResolveAll(serviceType);
            }
            else
            {
                return new List<object>();
            }
        }
    }
}