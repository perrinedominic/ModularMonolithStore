using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Products.Data;
using Web.Core.Modules.Products.Models;

namespace Web.Core.Modules.Products.Repositories
{

    public class ProductDiscountRepository : IGenericRepository<ProductDiscount>
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<ProductDiscount> _dbSet;

        public ProductDiscountRepository(ProductDbContext context)
        {
            _context = context;
            _dbSet = context.Set<ProductDiscount>();
        }

        public async Task<ProductDiscount?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<ProductDiscount>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(ProductDiscount productDiscount)
        {
            await _dbSet.AddAsync(productDiscount);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductDiscount productDiscount)
        {
            _dbSet.Update(productDiscount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductDiscount productDiscount)
        {
            if (productDiscount != null)
            {
                _dbSet.Remove(productDiscount);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
