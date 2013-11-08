using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.DataAccess;

namespace CG.Logic.Service.Interface
{
    public interface IUserService
    {
        User GetUserById(long id);
    }
}
