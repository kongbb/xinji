using System;

namespace CG.Access.MessageBus.Components
{
    public class MessageBusQueueBinding
    {
        #region Fields

        private readonly string _baseQueueName;
        private readonly string _baseRoutingKey;

        #endregion Fields

        #region Constructor

        public MessageBusQueueBinding(string baseQueueName, string baseRoutingKey = null)
        {
            if (String.IsNullOrWhiteSpace(baseQueueName))
            {
                throw new ArgumentNullException("baseQueueName",
                    "A queue binding must be initialised with a base queue name.");
            }

            _baseQueueName = baseQueueName;

            _baseRoutingKey = baseRoutingKey;
        }

        #endregion

        #region Properties

        public string BaseQueueName
        {
            get { return _baseQueueName; }
        }

        public string BaseRoutingKey
        {
            get { return _baseRoutingKey; }
        }

        #endregion Properties
    }
}