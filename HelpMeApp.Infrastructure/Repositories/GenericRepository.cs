using HelpMeApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HelpMeApp.Infrastructure.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private HelpMeAppDbContext _context;

        public GenericRepository(HelpMeAppDbContext _context)
        {
            this._context = _context;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> Get(Expression<System.Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetWithIncludes(params Expression<Func<T, object>>[] includes)
        {
           var dbSet = _context.Set<T>();

            IEnumerable<T> query = null;
            foreach (var include in includes)
            {
                query = dbSet.Include(include);
            }

            return query ?? dbSet;
        }
        public async Task<T> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task Insert(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
        }
        public void Update(T obj)
        {
            _context.Set<T>().Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(existing);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
