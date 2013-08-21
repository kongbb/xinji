using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.DataAccess.RepositoryInterface;
using CG.Logic.Domain.User;

namespace CG.Access.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Authenticate(string userName, string password)
        {
            return new User
            {
                UserName = userName,
                Roles = new List<string>()
            };
        }
    }
}
