using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CG.Logic.Domain;
using CG.Logic.DomainObject;

namespace CG.Presentation.WebApi.Controllers
{
    public class OrderController : ApiController
    {
        public ResponseDto<Table> GetAllTableStatus()
        {
            throw new NotImplementedException();
        }

        public ResponseDto<MenuItem> GetAllMenuItems()
        {
            throw new NotImplementedException();
        } 
    }
}
