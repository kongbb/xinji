using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace CG.Common.Helpers
{
    public static class UnityHelper
    {
        private static UnityContainer _container;

        public static UnityContainer Current { get; set; }
    }
}
