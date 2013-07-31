using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CG.Logic.DomainObject;
using CG.Presentation.WebHost.Models;

namespace CG.Presentation.WebHost.Controllers
{
    public class TestController : CgBaseController
    {
        #region Properties

        public TestModel TestModel { get; set; }

        #endregion

        #region Constructor

        public TestController()
        {
            
        }

        #endregion

        //
        // GET: /Test/

        public ActionResult Index()
        {
            LoadModel();
            return View(TestModel);
        }

        #region Private Methods

        private void LoadModel()
        {
            TestObject response = RequestManager.GetResponse<TestObject>("api/TestApi/GetMessageById/3");
            TestModel = new TestModel
                {
                    TestObject = response,
                };
        }

        #endregion
    }
}
