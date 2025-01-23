using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common.Interfaces;
using ModularMonolithStore.Modules.Products.Data;
using ModularMonolithStore.Modules.Products.Models;

namespace ModularMonolithStore.Modules.Products.Repositories
{

    public class ProductRatingRepository : IGenericRepository<ProductRating>
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<ProductRating> _dbSet;

        public ProductRatingRepository(ProductDbContext context)
        {
            _context = context;
            _dbSet = context.Set<ProductRating>();
        }

        public async Task<ProductRating?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<ProductRating>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(ProductRating productRating)
        {
            await _dbSet.AddAsync(productRating);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductRating productRating)
        {
            _dbSet.Update(productRating);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productRating = await GetByIdAsync(id);

            if (productRating != null)
            {
                _dbSet.Remove(productRating);
                await _context.SaveChangesAsync();
            }
        }
    }
}
