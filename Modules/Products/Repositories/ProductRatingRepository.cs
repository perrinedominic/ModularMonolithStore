using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Modules.Products.Models;
using ModularMonolithStore.Modules.Products.Repositories.Interfaces;

namespace ModularMonolithStore.Modules.Products.Repositories
{

    public class ProductRatingRepository : IRepository<ProductRating>
    {
        private readonly DbContext _context;
        private readonly DbSet<ProductRating> _dbSet;

        public ProductRatingRepository(DbContext context)
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
            bool exists = await _dbSet.AnyAsync(p => p.ProductId == productRating.ProductId && p.CustomerId == productRating.CustomerId);

            if (exists)
                throw new InvalidOperationException("The customer has already left a rating on this product.");

            await _dbSet.AddAsync(productRating);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductRating productRating)
        {
            if (productRating == null)
            {
                throw new ArgumentNullException(nameof(productRating), "Rating cannot be null.");
            }

            var currentProductBrand = await GetByIdAsync(productRating.Id)
                ?? throw new ArgumentNullException(nameof(productRating), "No matching Rating was found.");

            _context.Entry(currentProductBrand).CurrentValues.SetValues(productRating);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productRating = await GetByIdAsync(id);

            if (productRating != null)
            {
            _dbSet.Remove(productRating);
            }
        }
    }
}
