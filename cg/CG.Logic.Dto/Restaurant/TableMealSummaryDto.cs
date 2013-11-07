using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.DataAccess;
using CG.Logic.DomainObject;

namespace CG.Logic.Dto.Restaurant
{
    public class TableMealSummaryDto : BaseDto
    {
        #region constructor

        public TableMealSummaryDto(TableMeal tableMeal)
        {
            TableMealId = tableMeal.Id;
            TableMealStatusId = tableMeal.TableMealStatusId;
            TableMealStatus = tableMeal.TableMealStatu.Name;
            NumberOfGuests = tableMeal.NumberOfPeople;
            StartedTime = tableMeal.StartedTime;
            EndedTime = tableMeal.EndedTime;

            OrderItems = tableMeal.TotalOrderItems.Select(x => new OrderItemDto
            {
                MenuItemId = x.MenuItemId,
                Count = x.Count,
                ServedCount = x.ServedCount,
            }).ToList();
        }

        #endregion

        public long TableMealId { get; set; }

        public DateTime? StartedTime { get; set; }

        public DateTime? EndedTime { get; set; }

        public int? NumberOfGuests { get; set; }

        public long TableMealStatusId { get; set; }

        public string TableMealStatus { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }
    }
}
