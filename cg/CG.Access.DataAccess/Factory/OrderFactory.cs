using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Access.DataAccess.Factory
{
    public static class OrderFactory
    {
        public static Order CreateOrder(TableMeal tableMeal, long orderType)
        {
            return new Order
            {
                TableMeal = tableMeal,
                OrderTypeId = orderType,
            };
        }
    }
}
