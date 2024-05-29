namespace FinTech.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<bool> RemoveAsync(T entity);
        Task<bool> RemoveByIdAsync(int id);
        Task<bool> SaveChangesAsync();
        Task UpdateAsync(T entity);
    }
}
