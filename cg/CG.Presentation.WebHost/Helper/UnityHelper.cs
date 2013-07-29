using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace CG.Presentation.WebHost.Helper
{
    public static class UnityHelper
    {
        public static IUnityContainer Container { get; set; }
    }
}