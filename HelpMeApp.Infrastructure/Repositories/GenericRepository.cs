using HelpMeApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeApp.Infrastructure.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private HelpMeAppDbContext _context = null;
        private DbSet<T> _dbSet = null;

        //public GenericRepository()
        //{
        //    this._context = new HelpMeAppDbContext();
        //    _dbSet = _context.Set<T>();
        //}

        public GenericRepository(HelpMeAppDbContext _context)
        {
            this._context = _context;
            _dbSet = this._context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task Insert(T obj)
        {
            await _dbSet.AddAsync(obj);
        }
        public void Update(T obj)
        {
            _dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = _dbSet.Find(id);
            _dbSet.Remove(existing);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
