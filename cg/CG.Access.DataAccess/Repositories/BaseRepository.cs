using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace CG.Access.DataAccess.Repositories
{
    public class BaseRepository
    {
        [Dependency]
        protected Entities Context { get; set; }
    }
}
