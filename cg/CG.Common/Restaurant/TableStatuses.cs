using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Common.Restaurant
{
    public static class TableStatuses
    {
//        Id	Name
//1	Spare
//2	Occupied
//3	Ordering
//4	NeedWaiter
//5	Dining
//6	Billing
//7	NeedClean
        public const long Spare = 1;
        public const long Occupied = 2;
        public const long Ordering = 3;
        public const long NeedWaiter = 4;
        public const long Dining = 5;
        public const long Billing = 6;
        public const long NeedClean = 7;
    }
}
