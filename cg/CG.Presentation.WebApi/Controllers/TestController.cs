using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CG.Presentation.WebApi.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        [HttpPost]
        public ActionResult Index()
        {
            return JsonResult();
        }
    }
}
