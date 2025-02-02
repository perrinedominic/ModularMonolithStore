using ModularMonolithStore.Modules.Products.Models;

namespace ModularMonolithStore.Common
{
    public interface IGenericService<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
