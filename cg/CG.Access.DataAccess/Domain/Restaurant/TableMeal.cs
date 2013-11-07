using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Access.DataAccess
{
    public partial class TableMeal
    {
        public List<OrderItem> TotalOrderItems { get; set; } 

        public List<OrderItem> GetTableMealOrderItems()
        {
            var orderItems = new List<OrderItem>();
            foreach (var order in Orders)
            {
                orderItems.AddRange(order.OrderItems);
            }

            return orderItems;
        }
    }
}
