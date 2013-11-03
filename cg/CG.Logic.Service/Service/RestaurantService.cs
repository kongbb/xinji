using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.DataAccess.RepositoryInterface;
using CG.Logic.DomainObject;
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
                            select new TableSummaryDto
                                {
                                    TableId = table.Id,
                                    TableMeal = table.TableMeal == null ? null : new TableMealSummaryDto
                                        {
                                            TableMealId = table.TableMeal.Id,
                                            TableMealStatusId = table.TableMeal.TableMealStatusId,
                                            TableMealStatus = table.TableMeal.TableMealStatu.Name,
                                            NumberOfGuests = table.TableMeal.NumberOfPeople,
                                            StartedTime = table.TableMeal.StartedTime,
                                            EndedTime = table.TableMeal.EndedTime,
                                            OrderSummaries = null,
                                        },
                                    Code = table.Code,
                                    Seats = table.Seats,
                                    MaxSeats = table.MaxSeats,
                                    IsAvailable = table.IsAvailable,
                                };
                response.IsSuccessful = true;
                response.Payload = query.ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
