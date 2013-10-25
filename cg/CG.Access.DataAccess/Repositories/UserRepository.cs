using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.DataAccess.RepositoryInterface;
using Domain = CG.Logic.Domain;

namespace CG.Access.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Domain.User Authenticate(string userName, string password)
        {
            return new Domain.User
            {
                //Name = userName,
                //Roles = new List<string>()
            };
        }
    }
}
