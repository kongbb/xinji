using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Access.DataAccess
{
    public partial class Table
    {
        public long? CurrentTableMealId { get; set; }

        public TableMeal TableMeal { get; set; }
    }
}
