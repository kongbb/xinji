using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CG.Logic.DomainObject
{
    [Serializable]
    public class ListResponseDto<TDto> : BaseResponseDto where TDto : BaseDto
    {
        public List<TDto> Payload { get; set; }
    }
}
