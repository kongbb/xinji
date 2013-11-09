using System;
using System.Linq;
using CG.Access.DataAccess;
using CG.Access.DataAccess.Factory;
using CG.Access.DataAccess.RepositoryInterface;
using CG.Common.Constants;
using CG.Logic.DomainObject;
using CG.Logic.Dto.RequestDto;
using CG.Logic.Dto.Restaurant;
using CG.Logic.Service.Interface;
using Microsoft.Practices.Unity;

namespace CG.Logic.Service.Service
{
    public class RestaurantService : IRestaurantService
    {
        [Dependency]
        public IRestaurantRepository RestaurantRepository { get; set; }

        public ListResponseDto<TableSummaryDto> GetTableSummariesByRestaurantId(long restaurantId)
        {
            var response = new ListResponseDto<TableSummaryDto>();
            try
            {
                var tables = RestaurantRepository.GetTablesByRestaurantId(restaurantId);
                var query = from table in tables
                            select new TableSummaryDto(table);
                response.IsSuccessful = true;
                response.Payload = query.ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public VoidResponseDto MakeOrder(OrderRequestDto order)
        {
            var tableMeal = RestaurantRepository.GetCurrentTableMealByTableId(order.TableId);
            if (tableMeal == null)
            {
                tableMeal = TableMealFactory.CreateNewTableMeal(order.TableId, order.GuestNumber);
                RestaurantRepository.Add(tableMeal);
            }

            var newOrder = OrderFactory.CreateOrder(tableMeal, order.OrderTypeId);
            tableMeal.Orders.Add(newOrder);
            RestaurantRepository.Add(newOrder);
            foreach (var orderItem in order.Order)
            {
                var temp = OrderItemFactory.CreateOrderItem(orderItem.MenuItemId, orderItem.Count);
                newOrder.OrderItems.Add(temp);
            }

            RestaurantRepository.Commit();

            return new VoidResponseDto{IsSuccessful = true,};
        }
    }
}
