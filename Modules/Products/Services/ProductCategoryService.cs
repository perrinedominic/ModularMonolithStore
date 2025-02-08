using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Products.Data;
using Web.Core.Modules.Products.Models;
using Web.Core.Modules.Products.Services.Interfaces;

namespace Web.Core.Modules.Products.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductCategoryService : IGenericService<ProductCategory>
    {
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;

        public ProductCategoryService(IGenericRepository<ProductCategory> productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<ProductCategory?> GetByIdAsync(int id)
        {
            return await _productCategoryRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            return await _productCategoryRepository.GetAllAsync();
        }

        public async Task AddAsync(ProductCategory productCategory)
        {
            var productCategories = await _productCategoryRepository.GetAllAsync();
            bool exists = productCategories.Any(p => p.Name == productCategory.Name);

            if (exists)
                throw new InvalidOperationException("A category with the same name already exists.");

            await _productCategoryRepository.AddAsync(productCategory);
            await _productCategoryRepository.SaveAsync();
        }

        public async Task UpdateAsync(ProductCategory productCategory)
        {
            if (productCategory == null)
            {
                throw new ArgumentNullException(nameof(productCategory), "Brand cannot be null.");
            }

            var currentProductCategory = await GetByIdAsync(productCategory.Id)
                ?? throw new ArgumentNullException(nameof(productCategory), "No matching Brand was found.");

            await _productCategoryRepository.UpdateAsync(productCategory);
            await _productCategoryRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productCategory = await GetByIdAsync(id);

            if (productCategory != null)
            {
                await _productCategoryRepository.DeleteAsync(productCategory);
            }
        }
    }
}
