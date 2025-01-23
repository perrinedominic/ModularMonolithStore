using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common.Interfaces;
using ModularMonolithStore.Modules.Products.Data;
using ModularMonolithStore.Modules.Products.Models;

namespace ModularMonolithStore.Modules.Products.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductCategoryRepository : IGenericRepository<ProductCategory>
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<ProductCategory> _dbSet;

        public ProductCategoryRepository(ProductDbContext context)
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
            await _dbSet.AddAsync(productCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductCategory productCategory)
        {
            _dbSet.Update(productCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productCategory = await GetByIdAsync(id);

            if (productCategory != null)
            {
                _dbSet.Remove(productCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
