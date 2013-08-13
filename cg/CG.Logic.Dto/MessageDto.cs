using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CG.Logic.DomainObject
{
    [Serializable]
    public class MessageDto : BaseDto
    {
        public long SeverityId { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string Detail { get; set; }

        public string ValidationPath { get; set; }
    }
}
