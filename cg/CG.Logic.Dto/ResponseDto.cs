using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CG.Logic.DomainObject
{
    [DataContract]
    public class ResponseDto<T> : BaseResponseDto
    {
        [DataMember]
        public T Payload { get; set; }
    }
}
