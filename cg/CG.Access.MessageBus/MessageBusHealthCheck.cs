using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CG.Common.Helpers;
using EasyNetQ.Management.Client;

namespace CG.Access.MessageBus
{
    public class MessageBusHealthCheck
    {
        #region Fields

        private ManagementClient _managementClient;

        #endregion

        #region Properties

        private ManagementClient ManagementClient
        {
            get
            {
                if (_managementClient == null)
                {
                    string hostUrl = "http://" + ParameterHelper.MessageBusHostAddress;
                    _managementClient = new ManagementClient(hostUrl, 
                        ConfigManager.UserNameForConnection, ConfigManager.PasswordForConnection);
                }

                return _managementClient;
            }
        }

        private MessageBusConfigManager ConfigManager { get; set; }

        private string TargetBaseQueueName { get; set; }

        private Logger Logger
        {
            get
            {
                return LogManager.GetLogger(GetType().Name);
            }
        }

        private int ErrorMessageCountLastTime { get; set; }

        private int DeadMessageCountLastTime { get; set; }

        private List<string> WarningMessages { get; set; }

        private List<string> ErrorMessages { get; set; } 

        #endregion

        #region Constructor

        public MessageBusHealthCheck(MessageBusConfigManager configManager, string targetBaseQueueName)
        {
            ConfigManager = configManager;
            TargetBaseQueueName = targetBaseQueueName;
            ErrorMessageCountLastTime = 0;
            DeadMessageCountLastTime = 0;
        }

        public void Check()
        {
            WarningMessages = new List<string>();
            ErrorMessages = new List<string>();

            try
            {
                var queues = ManagementClient.GetQueues();

                // check target main queue
                var targetMainQueue =
                    queues.SingleOrDefault(
                        x => x.Name.Equals(ConfigManager.GetMainQueueName(TargetBaseQueueName)));
                if (targetMainQueue == null)
                {
                    string errorMessage =
                        string.Format(
                            "The Queue - {0} does not exist. Please check your RabbitMQ server.",
                            ConfigManager.GetMainQueueName(TargetBaseQueueName));
                    ErrorMessages.Add(errorMessage);
                }
                else
                {
                    if (targetMainQueue.Consumers == 0)
                    {
                        string errorMessage =
                            string.Format(
                                "There is no consumer of Queue - {0}. The Processor maybe down.",
                                ConfigManager.GetMainQueueName(TargetBaseQueueName));
                        ErrorMessages.Add(errorMessage);
                    }
                }

                // check target error queue
                var targetErrorQueue =
                    queues.SingleOrDefault(
                        x => x.Name.Equals(ConfigManager.GetErrorQueueName(TargetBaseQueueName)));
                if (targetErrorQueue == null)
                {
                    // The error queue, unlike dead queue, is created dynamically, only when the first error message
                    // goes into queue.
                    // so if the error queue doesn't exist, it is fine
                    ErrorMessageCountLastTime = 0;
                }
                else
                {
                    if (targetErrorQueue.Messages > 0 &&
                        targetErrorQueue.Messages != ErrorMessageCountLastTime)
                    {
                        //error action
                        string errorMessage = string.Format("There are {0} messages in {1}.",
                            targetErrorQueue.Messages,
                            ConfigManager.GetErrorQueueName(TargetBaseQueueName));
                        ErrorMessages.Add(errorMessage);
                    }

                    ErrorMessageCountLastTime = targetErrorQueue.Messages;
                }

                // check target deadletter queue
                var targetDeadLetterQueue =
                    queues.SingleOrDefault(
                        x => x.Name.Equals(ConfigManager.GetDeadLetterQueueName(TargetBaseQueueName)));
                if (targetDeadLetterQueue == null)
                {
                    string errorMessage =
                        string.Format(
                            "The Queue - {0} does not exist. Please check your RabbitMQ server.",
                            ConfigManager.GetDeadLetterQueueName(TargetBaseQueueName));
                    ErrorMessages.Add(errorMessage);
                    DeadMessageCountLastTime = 0;
                }
                else
                {
                    if (targetDeadLetterQueue.Messages > 0 &&
                        targetDeadLetterQueue.Messages != DeadMessageCountLastTime)
                    {
                        //warning action
                        string warningMessage = string.Format("There are {0} messages in {1}.",
                            targetDeadLetterQueue.Messages,
                            ConfigManager.GetDeadLetterQueueName(TargetBaseQueueName));
                        WarningMessages.Add(warningMessage);
                    }

                    DeadMessageCountLastTime = targetDeadLetterQueue.Messages;
                }

                // TODO for now we only check if there is any connection
                // we can check connection detail, like machine name, etc
                if (!ManagementClient.GetConnections().Any())
                {
                    // error action
                    string errorMessage =
                        string.Format(
                            "There is no connection to the RabbitMQ Server, check your processor.");
                    ErrorMessages.Add(errorMessage);
                }
            }
            catch (Exception e)
            {
                ErrorMessages.Add(e.Message);
                if (e.InnerException != null)
                {
                    ErrorMessages.Add(e.InnerException.Message);
                }
                ErrorMessages.Add(e.StackTrace);
            }
            finally
            {
                SendEmail();
            }
        }

        #endregion

        #region Private Methods

        private void SendEmail()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Health check finished at {0}.\n", TimeManager.Current.Now));
            
            foreach (var errorMessage in ErrorMessages)
            {
                sb.Append(string.Format("Error: {0}\n", errorMessage));
            }

            foreach (var warningMessage in WarningMessages)
            {
                sb.Append(string.Format("Warning: {0}\n", warningMessage));
            }

            if (ErrorMessages.Any())
            {
                Logger.Error(sb.ToString());
            }
            else
            {
                if (WarningMessages.Any())
                {
                    Logger.Warn(sb.ToString());
                }
            }
        }

        #endregion
    }
}
