using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Common.Helpers
{
    public static class ParameterHelper
    {
        public static string Environment
        {
            get { return "Dev"; }
        }

        #region MessageBus

        public static string MessageBusUserName
        {
            get { return "guest"; }
        }

        public static string MessageBusPassword
        {
            get
            {
                return "guest";
            }
        }

        public static string MessageBusHostAddress
        {
            get { return "127.0.0.1"; }
        }

        public static string MessageBusQueueBindingPrefix
        {
            get
            {
                return "CG-";
            }
        }

        #endregion
    }
}
