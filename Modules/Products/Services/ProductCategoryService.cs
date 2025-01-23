using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common.Interfaces;
using ModularMonolithStore.Modules.Products.Data;
using ModularMonolithStore.Modules.Products.Models;

namespace ModularMonolithStore.Modules.Products.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductCategoryService : IGenericService<ProductCategory>
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<ProductCategory> _dbSet;

        public ProductCategoryService(ProductDbContext context)
        {
            _context = context;
            _dbSet = context.Set<ProductCategory>();
        }

        public async Task<ProductCategory?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(ProductCategory productCategory)
        {
            bool exists = await _dbSet.AnyAsync(p => p.Name == productCategory.Name);

            if (exists)
                throw new InvalidOperationException("A category with the same name already exists.");

            await _dbSet.AddAsync(productCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductCategory productCategory)
        {
            if (productCategory == null)
            {
                throw new ArgumentNullException(nameof(productCategory), "Brand cannot be null.");
            }

            var currentProductCategory = await GetByIdAsync(productCategory.Id)
                ?? throw new ArgumentNullException(nameof(productCategory), "No matching Brand was found.");

            _context.Entry(currentProductCategory).CurrentValues.SetValues(productCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productCategory = await GetByIdAsync(id);

            if (productCategory != null)
            {
            _dbSet.Remove(productCategory);
            }
        }
    }
}
