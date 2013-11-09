using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Common.Utility
{
    public static class TimeManager
    {
        public static DateTime Now()
        {
            return DateTime.Now;
        }

        public static DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
