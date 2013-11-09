using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Common.Constants;
using CG.Common.Helpers;
using CG.Common.Utility;

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
                OrderStatusId = OrderStatuses.Ordered,
                CreatedBy = CurrentUserHelper.GetCurrentUserId().Value,
                CreatedDateTime = TimeManager.Now(),
                UpdatedBy = CurrentUserHelper.GetCurrentUserId().Value,
                UpdatedDateTime = TimeManager.Now(),
            };
        }
    }
}
