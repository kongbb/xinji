using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.DataAccess;
using CG.Access.DataAccess.RepositoryInterface;
using CG.Logic.Service.Interface;
using Microsoft.Practices.Unity;

namespace CG.Logic.Service.Service
{
    public class UserService : IUserService
    {
        [Dependency]
        public IUserRepository UserRepository { get; set; }

        public User GetUserById(long id)
        {
            return UserRepository.GetUserById(id);
        }
    }
}
