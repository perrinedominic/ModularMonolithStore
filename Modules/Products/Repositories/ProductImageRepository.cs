using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Products.Data;
using Web.Core.Modules.Products.Models;

namespace Web.Core.Modules.Products.Repositories
{

    public class ProductImageRepository : IGenericRepository<ProductImage>
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<ProductImage> _dbSet;

        public ProductImageRepository(ProductDbContext context)
        {
            _context = context;
            _dbSet = context.Set<ProductImage>();
        }

        public async Task<ProductImage?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<ProductImage>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(ProductImage productImage)
        {
            await _dbSet.AddAsync(productImage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductImage productImage)
        {
            _dbSet.Update(productImage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductImage productImage)
        {
            if (productImage != null)
            {
                _dbSet.Remove(productImage);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
