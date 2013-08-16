using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CG.Logic.DomainObject;
using CG.Logic.Dto.TestDtos;
using CG.Presentation.WebHost.Constants;
using CG.Presentation.WebHost.Models;
using RestSharp;

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
            return View(ViewNames.TestIndex, TestModel);
        }

        public ActionResult PublishMessage()
        {
            TestObjectDto postMessage = new TestObjectDto
            {
                Message = "Message posted from WebHost!"
            };
            var response = RequestManager.Post<ResponseDto<TestObjectDto>>("api/TestApi/PostMessage",
                postMessage);
            if (response.IsSuccessful)
            {
                TestModel = new TestModel
                {
                    TestObject = response.Payload,
                };
            }
            else
            {
                TestModel = new TestModel
                {
                    TestObject = new TestObjectDto
                    {
                        Message = response.Messages.First().Message,
                    },
                };
            }

            return View(ViewNames.TestIndex, TestModel);
        }

        #region Private Methods

        private void LoadModel()
        {
            var response = RequestManager.Get<ResponseDto<TestObjectDto>>("api/TestApi/GetMessageById/3");
            
            if (response.IsSuccessful)
            {
                TestModel = new TestModel
                {
                    TestObject = response.Payload,
                };
            }
            else
            {
                TestModel = new TestModel
                {
                    TestObject = new TestObjectDto
                    {
                        Message = response.Messages.First().Message,
                    },
                };
            }
        }

        #endregion
    }
}
