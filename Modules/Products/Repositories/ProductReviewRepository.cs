using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Modules.Products.Models;
using ModularMonolithStore.Modules.Products.Repositories.Interfaces;

namespace ModularMonolithStore.Modules.Products.Repositories
{

    public class ProductReviewRepository : IRepository<ProductReview>
    {
        private readonly DbContext _context;
        private readonly DbSet<ProductReview> _dbSet;

        public ProductReviewRepository(DbContext context)
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
            bool exists = await _dbSet.AnyAsync(p => p.CustomerId == productReview.CustomerId && p.ProductId == productReview.ProductId);

            if (exists)
                throw new InvalidOperationException("The customer has already left a review on this product.");

            await _dbSet.AddAsync(productReview);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductReview productReview)
        {
            if (productReview == null)
            {
                throw new ArgumentNullException(nameof(productReview), "Review cannot be null.");
            }

            var currentProductBrand = await GetByIdAsync(productReview.Id)
                ?? throw new ArgumentNullException(nameof(productReview), "No matching Review was found.");

            _context.Entry(currentProductBrand).CurrentValues.SetValues(productReview);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productReview = await GetByIdAsync(id);

            if (productReview != null)
            {
            _dbSet.Remove(productReview);
            }
        }
    }
}
