using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Common.Constants
{
    public static class TableMealStatuses
    {
        //        Id	Name
        //1	Spare
        //2	Occupied
        //3	Ordering
        //4	NeedWaiter
        //5	Dining
        //6	Billing
        //7	NeedClean
        public const long Opening = 1;
        public const long Ordering = 2;
        public const long Dining = 3;
        public const long Billing = 4;
    }
}
