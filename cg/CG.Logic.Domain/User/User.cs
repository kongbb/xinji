using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Logic.Domain.User
{
    public class User
    {
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
