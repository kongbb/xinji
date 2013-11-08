using System;
using System.Linq;

namespace CG.Access.DataAccess
{
    public partial class Table
    {
        public long? CurrentTableMealId { get; set; }

        public TableMeal CurrentTableMeal { get; set; }

        #region Methods

        public TableMeal GetCurrentTableMeal()
        {
            return TableMeals.SingleOrDefault(
                tm => tm.StartedTime < DateTime.Now && tm.EndedTime > DateTime.Now);
        }

        #endregion
    }
}
