using System;
using System.Text;
using CG.Access.MessageBus.Constants;
using EasyNetQ;
using EasyNetQ.SystemMessages;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace CG.Access.MessageBus.Components
{
    public class MessageBusConsumerErrorStrategy : DefaultConsumerErrorStrategy
    {
        private const int MaximumRetryCount = 3;
		private const string RetryHeader = RabbitMqConstants.HeadersKeyForRetryLimit;

		private readonly IEasyNetQLogger _logger;
		private readonly IConnectionFactory _connectionFactory;
		private readonly ISerializer _serializer;

        private string _errorExchangeName;
		private IConnection _connection;

		public MessageBusConsumerErrorStrategy(
            string errorExchangeName,
            IConnectionFactory connectionFactory, 
            ISerializer serializer, 
            IEasyNetQLogger logger, 
            IConventions conventions)
			: base(connectionFactory, serializer, logger, conventions)
		{
		    _errorExchangeName = errorExchangeName;
		    _connectionFactory = connectionFactory;
		    _serializer = serializer;
			_logger = logger;
		}

		#region IConsumerErrorStrategy Members

		public override void HandleConsumerError(BasicDeliverEventArgs deliveryArguments, Exception exception)
		{
			_logger.ErrorWrite(exception);

			var headers = deliveryArguments.BasicProperties.Headers;
		    if (!headers.Contains(RetryHeader))
		    {
		        headers.Add(RetryHeader, 0);
		    }

		    int retryCount = (int)headers[RetryHeader];
		    retryCount += 1;

			if (retryCount > MaximumRetryCount)
			{
				_logger.ErrorWrite("Message has exceeded the retry limit.");
				HandleWngConsumerError(deliveryArguments, exception);
				return;
			}

			headers[RetryHeader] = retryCount;

			_logger.ErrorWrite(String.Format("Message failed, but will retry ... (retry count '{0}': remaining '{1}')",
				retryCount, MaximumRetryCount - retryCount));

		    try
		    {
		        Connect();

		        using (var model = _connection.CreateModel())
		        {
		            model.BasicPublish(deliveryArguments.Exchange, deliveryArguments.RoutingKey,
		                deliveryArguments.BasicProperties, deliveryArguments.Body);
		        }
		    }
            catch (BrokerUnreachableException)
            {
                // thrown if the broker is unreachable during initial creation.
                _logger.ErrorWrite("Message Bus Consumer Error Handler cannot connect to Broker");
                _logger.ErrorWrite(CreateConnectionCheckMessage());
            }
            catch (OperationInterruptedException interruptedException)
            {
                // thrown if the broker connection is broken during declare or publish.
                _logger.ErrorWrite("Broker connection was closed while attempting to publish error message.\n" +
                        string.Format("Message was: '{0}'\n", interruptedException.Message) +
                        CreateConnectionCheckMessage());                
            }
            catch (Exception)
            {
                // Something else unexpected has gone wrong :(
                _logger.ErrorWrite("Failed to publish error message.");
            }
		}

        //public override PostExceptionAckStrategy PostExceptionAckStrategy()
        //{
        //    return EasyNetQ.PostExceptionAckStrategy.ShouldAck;
        //}

		#endregion

        #region Private Methods

		private void Connect()
		{
		    if (_connection == null || !_connection.IsOpen)
		    {
		        _connection = _connectionFactory.CreateConnection();
		    }
		}

        private void HandleWngConsumerError(BasicDeliverEventArgs deliveryArguments, Exception exception)
        {
            Connect();

            using (var model = _connection.CreateModel())
            {
                DeclareErrorExchangeQueueStructure(model, deliveryArguments.RoutingKey);

                var messageBody = CreateErrorMessage(deliveryArguments, exception);
                var properties = model.CreateBasicProperties();
                properties.SetPersistent(true);
                properties.Type = TypeNameSerializer.Serialize(typeof (Error));

                model.BasicPublish(_errorExchangeName, deliveryArguments.RoutingKey, properties, messageBody);
            }
        }

        private string GetErrorQueueName(string originalRoutingKey)
        {
            // Original queue name not available so use routing key for error queue name
            return originalRoutingKey.Replace('.', '_') + "_" + RabbitMqConstants.ErrorExchangeAndQueueNameSuffix;
        }

        private void DeclareErrorQueue(IModel model, string errorQueueName)
        {
            model.QueueDeclare(
                queue: errorQueueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        private void DeclareErrorExchangeAndBindErrorQueue(IModel model, 
            string errorQueueName, string originalRoutingKey)
        {
            model.ExchangeDeclare(_errorExchangeName, ExchangeType.Direct, durable: true);
            model.QueueBind(errorQueueName, _errorExchangeName, originalRoutingKey);
        }

        private void DeclareErrorExchangeQueueStructure(IModel model, string originalRoutingKey)
        {
            string errorQueueName = GetErrorQueueName(originalRoutingKey);

            DeclareErrorQueue(model, errorQueueName);

            DeclareErrorExchangeAndBindErrorQueue(model, errorQueueName, originalRoutingKey);
        }

        private byte[] CreateErrorMessage(BasicDeliverEventArgs deliveryArguments, Exception exception)
        {
            var messageAsString = Encoding.UTF8.GetString(deliveryArguments.Body);
            var error = new Error
            {
                RoutingKey = deliveryArguments.RoutingKey,
                Exchange = deliveryArguments.Exchange,
                Exception = exception.ToString(),
                Message = messageAsString,
                DateTime = DateTime.Now,
                BasicProperties = new MessageBasicProperties(deliveryArguments.BasicProperties)
            };

            return _serializer.MessageToBytes(error);
        }

        private string CreateConnectionCheckMessage()
        {
            return
                "Please check connection information and that the RabbitMQ Service is running at the specified endpoint.\n" +
                string.Format("\tHostname: '{0}'\n", _connectionFactory.CurrentHost.Host) +
                string.Format("\tVirtualHost: '{0}'\n", _connectionFactory.Configuration.VirtualHost) +
                string.Format("\tUserName: '{0}'\n", _connectionFactory.Configuration.UserName) +
                "Failed to write error message to error queue";
        }

        #endregion
    }
}
