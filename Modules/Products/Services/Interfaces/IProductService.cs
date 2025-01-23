using ModularMonolithStore.Common.Interfaces;
using ModularMonolithStore.Modules.Products.Models;

namespace ModularMonolithStore.Modules.Products.Services.Interfaces
{
    public interface IProductService : IGenericService<Product>
    {
        Task<IEnumerable<Product>> GetByBrandAsync(int brandId);
        Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetByTagAsync(int tagId);
        Task<IEnumerable<Product>> GetByDiscountAsync(int tagId);
    }
}
