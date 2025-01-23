using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common.Interfaces;
using ModularMonolithStore.Modules.Products.Data;
using ModularMonolithStore.Modules.Products.Models;

namespace ModularMonolithStore.Modules.Products.Repositories
{

    public class ProductReviewRepository : IGenericRepository<ProductReview>
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<ProductReview> _dbSet;

        public ProductReviewRepository(ProductDbContext context)
        {
            _context = context;
            _dbSet = context.Set<ProductReview>();
        }

        public async Task<ProductReview?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<ProductReview>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(ProductReview productReview)
        {
            await _dbSet.AddAsync(productReview);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductReview productReview)
        {
            _dbSet.Update(productReview);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productReview = await GetByIdAsync(id);

            if (productReview != null)
            {
                _dbSet.Remove(productReview);
                await _context.SaveChangesAsync();
            }
        }
    }
}
