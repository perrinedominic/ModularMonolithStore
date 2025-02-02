using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common;
using ModularMonolithStore.Modules.Orders.Data;
using ModularMonolithStore.Modules.Orders.Models;

namespace ModularMonolithStore.Modules.Orders.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderItemService : IGenericService<OrderItem>
    {
        private readonly OrderDbContext _context;
        private readonly DbSet<OrderItem> _dbSet;

        public OrderItemService(OrderDbContext context)
        {
            _context = context;
            _dbSet = context.Set<OrderItem>();
        }

        public async Task<OrderItem?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(OrderItem orderItem)
        {
            bool exists = await _dbSet.AnyAsync(o => o.Id == orderItem.Id);

            if (exists)
                throw new InvalidOperationException("A category with the same name already exists.");

            await _dbSet.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderItem orderItem)
        {
            if (orderItem == null)
            {
                throw new ArgumentNullException(nameof(orderItem), "Brand cannot be null.");
            }

            var currentOrderItem = await GetByIdAsync(orderItem.Id)
                ?? throw new ArgumentNullException(nameof(orderItem), "No matching Brand was found.");

            _context.Entry(currentOrderItem).CurrentValues.SetValues(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderItem = await GetByIdAsync(id);

            if (orderItem != null)
            {
            _dbSet.Remove(orderItem);
            }
        }
    }
}
