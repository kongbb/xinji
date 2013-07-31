using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CG.Logic.Dto;
using CG.Logic.Service.Interface;
using CG.Logic.Service.Service;

namespace CG.Presentation.WebApi.Controllers
{
    public class TestApiController : ApiController
    {
        protected ITestService TestService { get; set; }

        public TestApiController()
        {
            TestService = new TestService();
        }

        public TestObject GetMessageById(long id)
        {
            return TestService.GetTestMessageById(id);
        }
    }
}
