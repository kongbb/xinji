using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CG.Logic.DomainObject
{
    [DataContract]
    public abstract class BaseResponseDto
    {
        [DataMember]
        private List<MessageDto> _messages = new List<MessageDto>();

        [DataMember]
        public bool IsSuccessful { get; set; }

        [DataMember]
        public List<MessageDto> Messages
        {
            get
            {
                return this._messages;
            }
            set
            {
                this._messages = value;
            }
        }
    }
}
