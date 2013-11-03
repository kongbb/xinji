using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CG.Logic.DomainObject;
using CG.Logic.Dto.Restaurant;
using CG.Logic.Service.Interface;
using Microsoft.Practices.Unity;

namespace CG.Presentation.WebApi.Controllers
{
    public class RestaurantApiController : ApiController
    {
        [Dependency]
        protected IRestaurantService RestaurantService { get; set; }

        public ListResponseDto<TableSummaryDto> GetTablesByRestaurantId(long id)
        {
            var response = RestaurantService.GetTableSummariesByRestaurantId(id);
            return response;
        }

        //[HttpPost]
        //public VoidResponseDto AddRestaurant(RestaurantDto restaurantDto)
        //{
        //    var response = RestaurantService.AddRestaurant(postMessage);

        //    return response;
        //}

    }
}
