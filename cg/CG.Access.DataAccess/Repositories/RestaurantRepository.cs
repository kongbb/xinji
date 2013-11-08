using System.Collections.Generic;
using System.Linq;
using CG.Access.DataAccess.RepositoryInterface;

namespace CG.Access.DataAccess.Repositories
{
    public class RestaurantRepository : BaseRepository, IRestaurantRepository
    {
        public List<Table> GetTablesByRestaurantId(long restaurantId)
        {
            var availableTables = Context.Tables.Where(t => t.IsAvailable && t.RestaurantId == restaurantId).ToList();

            foreach (var table in availableTables)
            {
                table.CurrentTableMeal = table.GetCurrentTableMeal();
                if (table.CurrentTableMeal != null)
                {
                    table.CurrentTableMeal.TotalOrderItems =
                        table.CurrentTableMeal.GetTableMealOrderItems()
                             .GroupBy(oi => oi.MenuItemId)
                             .Select(m => new OrderItem
                             {
                                 MenuItemId = m.Key,
                                 Count = m.Sum(x => x.Count),
                                 ServedCount = m.Sum(x => x.Count),
                             }).ToList();
                }
            }

            return availableTables;
        }

        public TableMeal GetCurrentTableMealByTableId(long tableId)
        {
            return Context.Tables.Single(t => t.Id == tableId).GetCurrentTableMeal();
        }
    }
}
