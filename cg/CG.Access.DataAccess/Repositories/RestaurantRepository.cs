using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.DataAccess.RepositoryInterface;
using CG.Common.Restaurant;

namespace CG.Access.DataAccess.Repositories
{
    public class RestaurantRepository : BaseRepository, IRestaurantRepository
    {
        public List<Table> GetTablesByRestaurantId(long restaurantId)
        {
            var availableTables = Context.Tables.Where(t => t.IsAvailable && t.RestaurantId == restaurantId).ToList();

            foreach (var table in availableTables)
            {
                if (table.TableStatusId != TableStatuses.Spare && table.TableStatusId != TableStatuses.NeedClean)
                {
                    table.TableMeal =
                        Context.TableMeals.Where(tm => tm.TableId == table.Id)
                               .OrderByDescending(tm => tm.UpdatedDateTime)
                               .First();
                }
            }

            return availableTables;
        }
    }
}
