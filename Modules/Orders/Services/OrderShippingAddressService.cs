using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common;
using ModularMonolithStore.Modules.Orders.Data;
using ModularMonolithStore.Modules.Orders.Models;

namespace ModularMonolithStore.Modules.Orders.Services
{

    public class OrderShippingAddressService : IGenericService<OrderShippingAddress>
    {
        private readonly OrderDbContext _context;
        private readonly DbSet<OrderShippingAddress> _dbSet;

        public OrderShippingAddressService(OrderDbContext context)
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
            var currentOrderShippingAddress = await GetByIdAsync(orderShippingAddress.Id)
                ?? throw new ArgumentNullException(nameof(orderShippingAddress), "No matching Shipping Address was found.");

            _context.Entry(currentOrderShippingAddress).CurrentValues.SetValues(orderShippingAddress);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderShippingAddress = await GetByIdAsync(id);

            if (orderShippingAddress != null)
            {
            _dbSet.Remove(orderShippingAddress);
            }

            await _context.SaveChangesAsync();
        }
    }
}
