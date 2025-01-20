using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common.Interfaces;
using ModularMonolithStore.Modules.Products.Models;
using ModularMonolithStore.Modules.Products.Repositories.Interfaces;

namespace ModularMonolithStore.Modules.Products.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductRepository : IGenericRepository<Product>, IProductRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Product>();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// Adds a new product to the database. Checks if a product with the same name and brand already exists.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// If the product name is not unique within a specific brand, alert the user.
        /// </exception>
        public async Task AddAsync(Product product)
        {
            await _dbSet.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _dbSet.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);

            if (product != null)
            {
                _dbSet.Remove(product);
                await _context.SaveChangesAsync();
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
