using System.Linq.Expressions;

namespace Web.Core.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();  // Retrieve all entities of type T
        Task<T?> GetByIdAsync(int id);  // Retrieve a specific entity by ID
        Task AddAsync(T entity);  // Add a new entity of type T
        Task UpdateAsync(T entity);  // Update an existing entity of type T
        Task DeleteAsync(T entity);  // Delete an entity
        Task<int> SaveAsync();  // Persist changes to the database
    }
}
