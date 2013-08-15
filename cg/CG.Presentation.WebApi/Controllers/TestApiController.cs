using System.Web.Http;
using CG.Logic.DomainObject;
using CG.Logic.Dto.TestDtos;
using CG.Logic.Service.Interface;
using Microsoft.Practices.Unity;

namespace CG.Presentation.WebApi.Controllers
{
    public class TestApiController : ApiController
    {
        [Dependency]
        protected ITestService TestService { get; set; }

        public ResponseDto<TestObjectDto> GetMessageById(long id)
        {
            var response = TestService.GetTestMessageById(id);
            if (response.IsSuccessful)
            {
                return response;
            }

            return new ResponseDto<TestObjectDto>
            {
                Payload = new TestObjectDto
                {
                    Message = "This is test object created from ApiController, not returning from DB",
                }
            };
        }

        [HttpPost]
        public ResponseDto<TestObjectDto> PostMessage(TestObjectDto postMessage)
        {
            var response = new ResponseDto<TestObjectDto>();
            
            postMessage.Message = postMessage.Message + " - processed!";

            response.IsSuccessful = true;
            response.Payload = postMessage;
            
            return response;
        }
    }
}
