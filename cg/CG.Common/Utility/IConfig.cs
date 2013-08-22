using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Common.Utility
{
    public interface IConfig
    {
        int GetInt(string name);

        string GetString(string name);
    }
}
