using AutoMapper;
using Labb4___Library.Data;
using Microsoft.EntityFrameworkCore;
using Labb4___Library.Repository.IRepository;

namespace Labb4___Library.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbset;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            dbset = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await dbset.AddAsync(entity);
            await SaveAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            dbset.Update(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
           dbset.Remove(entity);
            await SaveAsync();
        }

        public async Task<List<T>> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> temp = dbset;
            if (filter != null)
            {
                temp = temp.Where(filter);
            }
            return await temp.ToListAsync();
        }

        public async Task<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> temp = dbset;
            if (!tracked == true)
            {
                temp = temp.AsNoTracking();
            }
            if (filter != null)
            {
                temp = temp.Where(filter);
            }
            return await temp.FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

      
    }

}
