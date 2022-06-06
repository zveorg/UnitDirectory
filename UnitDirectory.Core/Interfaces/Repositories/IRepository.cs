namespace UnitDirectory.Core.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task RemoveAsync(T entity);

        Task RemoveRangeAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetById(Guid id);
    }
}
