using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Logic.DomainObject;
using CG.Logic.Dto.Restaurant;

namespace CG.Logic.Service.Interface
{
    public interface IRestaurantService
    {
        ListResponseDto<TableSummaryDto> GetTableSummariesByRestaurantId(long restaurantId);
    }
}
