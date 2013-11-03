using System.Web.Http;
using CG.Logic.DomainObject;
using CG.Logic.Dto.TestDtos;
using CG.Logic.Service.Interface;
using CG.Presentation.WebApi.Authentication;
using Microsoft.Practices.Unity;

namespace CG.Presentation.WebApi.Controllers
{
    //[Authentication]
    public class TestApiController : ApiController
    {
        [Dependency]
        protected ITestService TestService { get; set; }

        public ResponseDto<TestObjectDto> GetMessageById(long id)
        {
            string s = User.Identity.Name;
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
