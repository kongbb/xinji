using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CG.Logic.Service.Interface;

namespace CG.Presentation.WebHost.Controllers
{
    public class TestController : Controller
    {
        #region Properties

        private ITestService TestService;

        #endregion

        #region Constructor

        public TestController(ITestService testService)
        {
            TestService = testService;
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
