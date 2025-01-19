using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Modules.Products.Models;
using ModularMonolithStore.Modules.Products.Repositories.Interfaces;

namespace ModularMonolithStore.Modules.Products.Repositories
{

    public class ProductTagRepository : IRepository<ProductTag>
    {
        private readonly DbContext _context;
        private readonly DbSet<ProductTag> _dbSet;

        public ProductTagRepository(DbContext context)
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
            bool exists = await _dbSet.AnyAsync(p => p.Name == productTag.Name);

            if (exists)
                throw new InvalidOperationException("A brand with the same name already exists.");

            await _dbSet.AddAsync(productTag);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductTag productTag)
        {
            if (productTag == null)
            {
                throw new ArgumentNullException(nameof(productTag), "Brand cannot be null.");
            }

            var currentProductBrand = await GetByIdAsync(productTag.Id)
                ?? throw new ArgumentNullException(nameof(productTag), "No matching Brand was found.");

            _context.Entry(currentProductBrand).CurrentValues.SetValues(productTag);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productTag = await GetByIdAsync(id);

            if (productTag != null)
            {
            _dbSet.Remove(productTag);
            }
        }
    }
}
