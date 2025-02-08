using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Products.Data;
using Web.Core.Modules.Products.Models;
using Web.Core.Modules.Products.Services.Interfaces;

namespace Web.Core.Modules.Products.Repositories
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

        public async Task DeleteAsync(ProductReview productReview)
        {
            if (productReview != null)
            {
                _dbSet.Remove(productReview);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
