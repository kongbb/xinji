using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Logic.DomainObject;

namespace CG.Logic.Dto.Restaurant
{
    public class TableSummaryDto : BaseDto
    {
        #region Properties

        public long TableId { get; set; }

        public TableMealSummaryDto TableMeal { get; set; }

        public string Code { get; set; }

        public int Seats { get; set; }

        public int MaxSeats { get; set; }

        public bool IsAvailable { get; set; }

        #endregion   
    }
}
