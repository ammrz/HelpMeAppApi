using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Infrastructure.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Get(Expression<System.Func<T, bool>> filter);
        Task<T> GetById(object id);
        Task Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        Task Save();
    }
}
