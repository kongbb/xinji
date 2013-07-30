using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CG.Presentation.WebHost.Controllers
{
    public class TestController : Controller
    {
        #region Properties


        #endregion

        #region Constructor

        //public TestController(ITestService testService)
        //{
        //    TestService = testService;
        //}

        public TestController()
        {
            
        }

        #endregion

        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }

    }
}
