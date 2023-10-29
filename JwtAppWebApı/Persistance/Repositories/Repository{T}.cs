using JwtAppWebApı.Core.Application.Interfaces;
using JwtAppWebApı.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JwtAppWebApı.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly JwtAndCQRSAppContext context;

        public Repository(JwtAndCQRSAppContext context)
        {
            this.context = context;
        }

        public async  Task CreateAsync(T entity)
        {
           await this.context.Set<T>().AddAsync(entity);
           await this.context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsnyc()
        {
            return await this.context.Set<T>().AsNoTracking().ToListAsync();

        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await this.context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await this.context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            this.context.Set<T>().Remove(entity);
           await this.context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this.context.Set<T>().Update(entity);
            await this.context.SaveChangesAsync();
        }
    }
}
