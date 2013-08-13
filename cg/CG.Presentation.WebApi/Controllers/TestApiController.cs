using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CG.Logic.Dto.TestDtos;
using CG.Logic.Service.Interface;
using CG.Logic.Service.Service;

namespace CG.Presentation.WebApi.Controllers
{
    public class TestApiController : ApiController
    {
        protected ITestService TestService { get; set; }

        public TestApiController(ITestService testService)
        {
            TestService = testService;
        }

        public TestObjectDto GetMessageById(long id)
        {
            var response = TestService.GetTestMessageById(id);
            if (response.IsSuccessful)
            {
                return response.Payload;
            }

            return new TestObjectDto
            {
                Message = "This is test object created from ApiController, not returning from DB",
            };
        }
    }
}
