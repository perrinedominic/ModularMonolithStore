using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common.Interfaces;
using ModularMonolithStore.Modules.Products.Data;
using ModularMonolithStore.Modules.Products.Models;

namespace ModularMonolithStore.Modules.Products.Services
{

    public class ProductDiscountService : IGenericService<ProductDiscount>
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<ProductDiscount> _dbSet;

        public ProductDiscountService(ProductDbContext context)
        {
            _context = context;
            _dbSet = context.Set<ProductDiscount>();
        }

        public async Task<ProductDiscount?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<ProductDiscount>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(ProductDiscount productDiscount)
        {
            bool exists = await _dbSet.AnyAsync(p => p.DiscountCode == productDiscount.DiscountCode);

            if (exists)
                throw new InvalidOperationException("The discount code already exists.");

            await _dbSet.AddAsync(productDiscount);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductDiscount productDiscount)
        {
            if (productDiscount == null)
            {
                throw new ArgumentNullException(nameof(productDiscount), "Discount cannot be null.");
            }

            var currentProductBrand = await GetByIdAsync(productDiscount.Id)
                ?? throw new ArgumentNullException(nameof(productDiscount), "No matching Discount was found.");

            _context.Entry(currentProductBrand).CurrentValues.SetValues(productDiscount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productDiscount = await GetByIdAsync(id);

            if (productDiscount != null)
            {
            _dbSet.Remove(productDiscount);
            }
        }
    }
}
