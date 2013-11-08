using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.DataAccess.RepositoryInterface;

namespace CG.Access.DataAccess.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public User Authenticate(string userName, string password)
        {
            return new User
            {
                //Name = userName,
                //Roles = new List<string>()
            };
        }

        public User GetUserById(long id)
        {
            return Context.Users.Single(u => u.Id == id);
        }
    }
}
