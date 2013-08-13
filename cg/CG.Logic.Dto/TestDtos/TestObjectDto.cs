using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CG.Logic.DomainObject;

namespace CG.Logic.Dto.TestDtos
{
    public class TestObjectDto : BaseDto
    {
        public long Id { get; set; }

        public string Message { get; set; }
    }
}
