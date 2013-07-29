using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.DataAccess.RepositoryInterface;

namespace CG.Access.DataAccess.Repositories
{
    public class TestRepository : ITestRepository
    {
        public string GetTestMessage()
        {
            return "Hello World!";
        }
    }
}
