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
using Microsoft.Practices.Unity;

namespace CG.Logic.Service.Service
{
    public class TestService : ITestService
    {
        [Dependency]
        private ITestRepository TestRepository { get; set; }

        public ResponseDto<TestObjectDto> GetTestMessageById(long messageId)
        {
            var testMessage = TestRepository.GetTestMessageById(messageId);
            if (testMessage != null)
            {
                return new ResponseDto<TestObjectDto>
                {
                    Payload = new TestObjectDto
                    {
                        Id = testMessage.Id,
                        Message = testMessage.Description,
                    }
                };
            }
            
            return new ResponseDto<TestObjectDto>
            {
                IsSuccessful = false,
            };
        }
    }
}
