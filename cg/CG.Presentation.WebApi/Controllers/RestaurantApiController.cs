using System.Collections.Generic;
using System.Web.Http;
using CG.Common.Helpers;
using CG.Logic.DomainObject;
using CG.Logic.Dto.RequestDto;
using CG.Logic.Dto.Restaurant;
using CG.Logic.Service.Interface;
using Microsoft.Practices.Unity;

namespace CG.Presentation.WebApi.Controllers
{
    public class RestaurantApiController : ApiController
    {
        [Dependency]
        protected IRestaurantService RestaurantService { get; set; }

        [Dependency]
        protected IUserService UserService { get; set; }

        public ListResponseDto<TableSummaryDto> GetTablesByRestaurantId(long id)
        {
            var response = RestaurantService.GetTableSummariesByRestaurantId(id);
            return response;
        }

        public ListResponseDto<TableSummaryDto> GetTables()
        {
            // hardcode
            CurrentUserHelper.SetCurrentUserId(1);
            var user = UserService.GetUserById(CurrentUserHelper.GetCurrentUserId().Value);
            var response = RestaurantService.GetTableSummariesByRestaurantId(user.RestaurantId);
            return response;
        }

        [HttpPost]
        public VoidResponseDto MakeOrder(OrderRequestDto order)
        {
            var response = RestaurantService.MakeOrder(order);
        }
        //[HttpPost]
        //public VoidResponseDto AddRestaurant(RestaurantDto restaurantDto)
        //{
        //    var response = RestaurantService.AddRestaurant(postMessage);

        //    return response;
        //}

    }
}
