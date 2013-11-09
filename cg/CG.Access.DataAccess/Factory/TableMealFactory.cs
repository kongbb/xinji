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
    public static class TableMealFactory
    {
        public static TableMeal CreateNewTableMeal(long tableId, int guestNumber)
        {
            return new TableMeal
            {
                TableId = tableId,
                NumberOfPeople = guestNumber,
                TableMealStatusId = TableMealStatuses.Opening,
                UpdatedBy = CurrentUserHelper.GetCurrentUserId().Value,
                UpdatedDateTime = TimeManager.Now(),
            };
        }
    }
}
