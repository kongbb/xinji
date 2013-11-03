using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CG.Logic.DomainObject
{
    [DataContract]
    public class ListResponseDto<TDto> : BaseResponseDto where TDto : BaseDto
    {
        [DataMember]
        public List<TDto> Payload { get; set; }
    }
}
