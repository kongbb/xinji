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
            return response;
        }

        [HttpPost]
        public VoidResponseDto PostMessage(TestObjectDto postMessage)
        {
            var response = TestService.PublishMessage(postMessage);

            return response;
        }
    }
}
