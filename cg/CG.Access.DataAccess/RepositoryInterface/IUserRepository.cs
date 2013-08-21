using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Logic.Domain.User;

namespace CG.Access.DataAccess.RepositoryInterface
{
    public interface IUserRepository
    {
        User Authenticate(string userName, string password);
    }
}
