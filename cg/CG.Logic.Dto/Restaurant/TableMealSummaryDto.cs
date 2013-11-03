using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Logic.DomainObject;

namespace CG.Logic.Dto.Restaurant
{
    public class TableMealSummaryDto : BaseDto
    {
        public long TableMealId { get; set; }

        public DateTime? StartedTime { get; set; }

        public DateTime? EndedTime { get; set; }

        public int? NumberOfGuests { get; set; }

        public long TableMealStatusId { get; set; }

        public string TableMealStatus { get; set; }

        public List<OrderSummaryDto> OrderSummaries { get; set; }
    }
}
