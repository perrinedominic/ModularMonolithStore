using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common.Interfaces;
using ModularMonolithStore.Modules.Products.Models;
using ModularMonolithStore.Modules.Products.Repositories.Interfaces;

namespace ModularMonolithStore.Modules.Products.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductBrandService : IGenericService<ProductBrand>
    {
        private readonly DbContext _context;
        private readonly DbSet<ProductBrand> _dbSet;

        public ProductBrandService(DbContext context)
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
            bool exists = await _dbSet.AnyAsync(p => p.Name == productBrand.Name);

            if (exists)
                throw new InvalidOperationException("A brand with the same name already exists.");

            await _dbSet.AddAsync(productBrand);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductBrand productBrand)
        {
            if (productBrand == null)
            {
                throw new ArgumentNullException(nameof(productBrand), "Brand cannot be null.");
            }

            var currentProductBrand = await GetByIdAsync(productBrand.Id)
                ?? throw new ArgumentNullException(nameof(productBrand), "No matching Brand was found.");

            _context.Entry(currentProductBrand).CurrentValues.SetValues(productBrand);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productBrand = await GetByIdAsync(id);

            if (productBrand != null)
            {
            _dbSet.Remove(productBrand);
            }
        }
    }
}
