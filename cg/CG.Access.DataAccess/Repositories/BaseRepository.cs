using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.DataAccess.RepositoryInterface;
using Microsoft.Practices.Unity;

namespace CG.Access.DataAccess.Repositories
{
    public class BaseRepository : IRepository
    {
        [Dependency]
        protected Entities Context { get; set; }

        public T Add<T>(T entity) where T : class 
        {
            return Context.Set<T>().Add(entity);
        }

        public IEnumerable<T> Add<T>(List<T> list) where T : class
        {
            return Context.Set<T>().AddRange(list);
        }

        public T Remove<T>(T entity) where T : class
        {
            return Context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> Remove<T>(List<T> list) where T : class
        {
            return Context.Set<T>().RemoveRange(list);
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }
    }
}
