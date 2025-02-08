using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Orders.Data;
using Web.Core.Modules.Orders.Models;

namespace Web.Core.Modules.Orders.Repositories
{
    public class OrderItemRepository : IGenericRepository<OrderItem>
    {
        private readonly OrderDbContext _context;
        private readonly DbSet<OrderItem> _dbSet;

        public OrderItemRepository(OrderDbContext context)
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
            await _dbSet.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderItem orderItem)
        {
            _dbSet.Update(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(OrderItem orderItem)
        {
            if (orderItem != null)
            {
                _dbSet.Remove(orderItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
