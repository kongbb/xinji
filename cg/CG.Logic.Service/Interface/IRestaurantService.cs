using CG.Access.DataAccess.RepositoryInterface;
using CG.Logic.DomainObject;
using CG.Logic.Dto.RequestDto;
using CG.Logic.Dto.Restaurant;

namespace CG.Logic.Service.Interface
{
    public interface IRestaurantService
    {
        ListResponseDto<TableSummaryDto> GetTableSummariesByRestaurantId(long restaurantId);

        VoidResponseDto MakeOrder(OrderRequestDto order);
    }
}
