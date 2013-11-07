using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Common.Restaurant;

namespace CG.Access.DataAccess
{
    public partial class Table
    {
        public long? CurrentTableMealId { get; set; }

        public TableMeal CurrentTableMeal { get; set; }

        #region Methods

        public TableMeal GetCurrentTableMeal()
        {
            if (TableStatusId == TableStatuses.Spare || TableStatusId == TableStatuses.NeedClean)
            {
                return null;
            }
            
            return TableMeals.OrderByDescending(tm => tm.UpdatedDateTime).First();
        }

        #endregion
    }
}
