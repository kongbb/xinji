using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Access.DataAccess.RepositoryInterface
{
    public interface IRepository
    {
        T Add<T>(T entity) where T : class;

        IEnumerable<T> Add<T>(List<T> list) where T : class;

        T Remove<T>(T entity) where T : class;

        IEnumerable<T> Remove<T>(List<T> list) where T : class;

        int Commit();
    }
}
