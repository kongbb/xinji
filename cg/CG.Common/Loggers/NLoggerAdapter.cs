using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace CG.Common.Loggers
{
    public class NLoggerAdapter : ILogger
    {
        private Logger Logger
        {
            get
            {
                return LogManager.GetLogger(GetType().Name);
            }
        }

        public void Error(Exception e)
        {
            Logger.ErrorException(null, e);
        }

        public void Error(string format, params object[] args)
        {
            Logger.Error(format, args);
        }

        public void Error(string message)
        {
            Logger.Error(message);
        }

        public void Warning(Exception e)
        {
            Logger.WarnException(null, e);
        }

        public void Warning(string message)
        {
            Logger.Warn(message);
        }

        public void Debug(string message)
        {
            Logger.Debug(message);
        }

        public void Debug(string format, params object[] args)
        {
            Logger.Debug(format, args);
        }

        public void Info(string format, params object[] args)
        {
            Logger.Info(format, args);
        }
    }
}
