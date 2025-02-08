using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Orders.Data;
using Web.Core.Modules.Orders.Models;
using System.Xml.Linq;

namespace Web.Core.Modules.Orders.Repositories
{

    public class OrderShippingAddressRepository : IGenericRepository<OrderShippingAddress>
    {
        private readonly OrderDbContext _context;
        private readonly DbSet<OrderShippingAddress> _dbSet;

        public OrderShippingAddressRepository(OrderDbContext context)
        {
            _context = context;
            _dbSet = context.Set<OrderShippingAddress>();
        }

        public async Task<OrderShippingAddress?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<OrderShippingAddress>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(OrderShippingAddress orderShippingAddress)
        {
            await _dbSet.AddAsync(orderShippingAddress);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderShippingAddress orderShippingAddress)
        {
            _dbSet.Update(orderShippingAddress);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(OrderShippingAddress orderShippingAddress)
        {
            if (orderShippingAddress != null)
            {
                _dbSet.Remove(orderShippingAddress);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
