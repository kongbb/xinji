using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CG.Logic.DomainObject
{
    [Serializable]
    public abstract class BaseResponseDto
    {
        private List<MessageDto> _messages = new List<MessageDto>();

        public bool IsSuccessful { get; set; }

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
