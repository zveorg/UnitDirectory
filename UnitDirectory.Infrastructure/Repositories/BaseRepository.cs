using Microsoft.EntityFrameworkCore;
using UnitDirectory.Core.Entities;
using UnitDirectory.Core.Interfaces.Repositories;
using UnitDirectory.Infrastructure.EntityFramework;

namespace UnitDirectory.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity<Guid>
    {
        protected readonly DatabaseContext Context;

        protected BaseRepository(DatabaseContext databaseContext)
        {
            Context = databaseContext;
        }

        public async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().AsQueryable().ToListAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
