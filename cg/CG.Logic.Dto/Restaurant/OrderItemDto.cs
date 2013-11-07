using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Logic.DomainObject;

namespace CG.Logic.Dto.Restaurant
{
    public class OrderItemDto : BaseDto
    {
        public long TableMealId { get; set; }

        public long MenuItemId { get; set; }

        public int Count { get; set; }

        public int ServedCount { get; set; }
    }
}
