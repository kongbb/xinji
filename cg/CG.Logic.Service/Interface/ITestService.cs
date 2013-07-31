using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Logic.Dto;

namespace CG.Logic.Service.Interface
{
    public interface ITestService
    {
        TestObject GetTestMessageById(long messageId);
    }
}
