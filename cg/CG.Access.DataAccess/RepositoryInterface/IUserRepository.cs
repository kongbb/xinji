using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = CG.Logic.Domain;

namespace CG.Access.DataAccess.RepositoryInterface
{
    public interface IUserRepository
    {
        Domain.User Authenticate(string userName, string password);
    }
}
