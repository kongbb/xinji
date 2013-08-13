using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Logic.DomainObject;
using CG.Logic.Dto.TestDtos;

namespace CG.Logic.Service.Interface
{
    public interface ITestService
    {
        ResponseDto<TestObject> GetTestMessageById(long messageId);
    }
}
