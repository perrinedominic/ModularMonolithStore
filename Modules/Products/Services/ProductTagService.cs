using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common.Interfaces;
using ModularMonolithStore.Modules.Products.Data;
using ModularMonolithStore.Modules.Products.Models;

namespace ModularMonolithStore.Modules.Products.Services
{

    public class ProductTagService : IGenericService<ProductTag>
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<ProductTag> _dbSet;

        public ProductTagService(ProductDbContext context)
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
