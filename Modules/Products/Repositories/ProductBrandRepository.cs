using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Products.Data;
using Web.Core.Modules.Products.Models;

namespace Web.Core.Modules.Products.Repositories
{
    public class ProductBrandRepository : IGenericRepository<ProductBrand>
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<ProductBrand> _dbSet;

        public ProductBrandRepository(ProductDbContext context)
        {
            _context = context;
            _dbSet = context.Set<ProductBrand>();
        }

        public async Task<ProductBrand?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<ProductBrand>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(ProductBrand productBrand)
        {
            await _dbSet.AddAsync(productBrand);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductBrand productBrand)
        {
            _dbSet.Update(productBrand);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductBrand productBrand)
        {
            if (productBrand != null)
            {
                _dbSet.Remove(productBrand);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
