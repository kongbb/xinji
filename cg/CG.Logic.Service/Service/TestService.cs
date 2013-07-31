using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.DataAccess.Repositories;
using CG.Access.DataAccess.RepositoryInterface;
using CG.Logic.Dto;
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

        public TestObject GetTestMessageById(long messageId)
        {
            var testMessage = TestRepository.GetTestMessageById(messageId);
            if (testMessage != null)
            {
                return new TestObject
                    {
                        Id = testMessage.Id,
                        Message = testMessage.Description,
                    };
            }

            return new TestObject
                {
                    Id = 3,
                    Message = "Hello Roger!"
                };
        }
    }
}
