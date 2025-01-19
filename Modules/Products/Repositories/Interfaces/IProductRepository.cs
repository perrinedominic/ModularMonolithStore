using ModularMonolithStore.Modules.Products.Models;

namespace ModularMonolithStore.Modules.Products.Repositories.Interfaces
{
    /// <summary>
    /// Repository interface with methods specific to the Product Model
    /// </summary>
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByBrandAsync(int brandId);
        Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetByTagAsync(int tagId);
        Task<IEnumerable<Product>> GetByDiscountAsync(int tagId);
    }
}
