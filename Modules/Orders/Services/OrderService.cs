using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common;
using ModularMonolithStore.Modules.Orders.Data;
using ModularMonolithStore.Modules.Orders.Models;
using ModularMonolithStore.Modules.Products.Services.Interfaces;

namespace ModularMonolithStore.Modules.Orders.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderService : IGenericService<Order>, IOrderService
    {
        private readonly OrderDbContext _context;
        private readonly DbSet<Order> _dbSet;

        public OrderService(OrderDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Order>();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            bool exists = await _dbSet.AnyAsync(o => o.Id == order.Id);

            if (exists)
                throw new InvalidOperationException("A brand with the same name already exists.");

            await _dbSet.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Brand cannot be null.");
            }

            var currentOrderBrand = await GetByIdAsync(order.Id)
                ?? throw new ArgumentNullException(nameof(order), "No matching Brand was found.");

            _context.Entry(currentOrderBrand).CurrentValues.SetValues(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderService = await GetByIdAsync(id);

            if (orderService != null)
            {
            _dbSet.Remove(orderService);
            }
        }

        public Task<IEnumerable<Order>> GetByOrderItemAsync(int orderItemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetByPaymentAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetByShippingAddressAsync(int tagId)
        {
            throw new NotImplementedException();
        }
    }
}
