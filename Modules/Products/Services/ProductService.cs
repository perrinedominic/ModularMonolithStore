using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common.Interfaces;
using ModularMonolithStore.Modules.Products.Data;
using ModularMonolithStore.Modules.Products.Models;
using ModularMonolithStore.Modules.Products.Repositories.Interfaces;
using ModularMonolithStore.Modules.Products.Services.Interfaces;

namespace ModularMonolithStore.Modules.Products.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductService : IGenericService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly DbSet<Product> _dbSet;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        /// <summary>
        /// Adds a new product to the database. Checks if a product with the same name and brand already exists.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// If the product name is not unique within a specific brand, alert the user.
        /// </exception>
        public async Task AddAsync(Product product)
        {
            var existingProduct = await _dbSet
            .Where(p => p.Name == product.Name && p.Brand == product.Brand)
            .FirstOrDefaultAsync();

            if (existingProduct != null)
            {
                throw new InvalidOperationException("The product name already exists for this brand. Please use a unique name.");
            }

            await _productRepository.AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Image cannot be null.");
            }

            var currentProduct = await GetByIdAsync(product.Id)
                ?? throw new ArgumentNullException(nameof(product), "No matching Image was found.");

            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product != null)
            {
                await _productRepository.DeleteAsync(product.Id);
            }
        }

        public async Task<IEnumerable<Product>> GetByBrandAsync(int brandId)
        {
            return await _dbSet.Where(p => p.Brand.Id == brandId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
        {
            return await _dbSet.Where(p => p.Category.Id == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByTagAsync(int tagId)
        {
            return await _dbSet.Where(p => p.Tag.Id == tagId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByDiscountAsync(int discountId)
        {
            return await _dbSet.Where(p => p.Discount.Id == discountId).ToListAsync();
        }
    }
}
