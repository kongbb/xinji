using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Access.DataAccess.Factory
{
    public static class OrderItemFactory
    {
        public static OrderItem CreateOrderItem(long menuItemId, int count)
        {
            return new OrderItem
            {
                MenuItemId = menuItemId,
                Count = count,
                ServedCount = 0,
            };
        }
    }
}
