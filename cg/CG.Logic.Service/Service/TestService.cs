using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.DataAccess.Repositories;
using CG.Access.DataAccess.RepositoryInterface;
using CG.Logic.DomainObject;
using CG.Logic.Dto;
using CG.Logic.Dto.TestDtos;
using CG.Logic.Service.Interface;

namespace CG.Logic.Service.Service
{
    public class TestService : ITestService
    {
        private ITestRepository TestRepository { get; set; }

        public TestService()
        {
            TestRepository = new TestRepository();
        }

        public ResponseDto<TestObject> GetTestMessageById(long messageId)
        {
            var testMessage = TestRepository.GetTestMessageById(messageId);
            if (testMessage != null)
            {
                return new ResponseDto<TestObject>
                {
                    Payload = new TestObject
                    {
                        Id = testMessage.Id,
                        Message = testMessage.Description,
                    }
                };
            }
            
            return new ResponseDto<TestObject>
            {
                IsSuccessful = false,
            };
        }
    }
}
