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
            get { throw new NotImplementedException(); }
        }

        public static string MessageBusPassword
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static string MessageBusHostAddress
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static string MessageBusQueueBindingPrefix
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
