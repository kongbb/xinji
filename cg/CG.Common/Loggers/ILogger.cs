using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Common.Loggers
{
    public interface ILogger
    {
        void Error(Exception e);

        void Error(string format, params object[] args);

        void Error(string message);

        void Warning(Exception e);

        void Warning(string message);

        void Debug(string message);

        void Debug(string format, params object[] args);

        void Info(string format, params object[] args);
    }
}
