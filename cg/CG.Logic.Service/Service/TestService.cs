using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.DataAccess.RepositoryInterface;
using CG.Logic.Service.Interface;

namespace CG.Logic.Service.Service
{
    public class TestService : ITestService
    {
        private ITestRepository TestRepository;

        public string Ping(string message)
        {
            return TestRepository.GetTestMessage();
        }
    }
}
