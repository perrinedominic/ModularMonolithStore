namespace ModularMonolithStore.Modules.Products.Repositories.Interfaces
{
    /// <summary>
    /// Generic repository interface for CRUD implementation across all Models
    /// </summary>
    /// <typeparam name="T">Type of the Model that implements the Interface</typeparam>
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
