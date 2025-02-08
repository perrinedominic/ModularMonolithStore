using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Products.Data;
using Web.Core.Modules.Products.Models;
using Web.Core.Modules.Products.Services.Interfaces;

namespace Web.Core.Modules.Products.Repositories
{

    public class ProductTagRepository : IGenericRepository<ProductTag>
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<ProductTag> _dbSet;

        public ProductTagRepository(ProductDbContext context)
        {
            _context = context;
            _dbSet = context.Set<ProductTag>();
        }

        public async Task<ProductTag?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<ProductTag>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(ProductTag productTag)
        {
            await _dbSet.AddAsync(productTag);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductTag productTag)
        {
            _dbSet.Update(productTag);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductTag productTag)
        {
            if (productTag != null)
            {
                _dbSet.Remove(productTag);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
