using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Access.DataAccess.RepositoryInterface
{
    public interface ITestRepository : IRepository
    {
        TestTable GetTestMessageById(long messageId);
    }
}
