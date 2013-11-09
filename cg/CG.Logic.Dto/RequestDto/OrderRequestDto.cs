using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Logic.DomainObject;
using CG.Logic.Dto.Restaurant;

namespace CG.Logic.Dto.RequestDto
{
    public class OrderRequestDto : BaseDto
    {
        public long TableId { get; set; }

        public long OrderTypeId { get; set; }

        public int GuestNumber { get; set; }

        public List<OrderItemDto> Order { get; set; }
    }
}
