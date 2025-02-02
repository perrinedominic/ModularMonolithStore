using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common;
using ModularMonolithStore.Modules.Orders.Data;
using ModularMonolithStore.Modules.Orders.Models;

namespace ModularMonolithStore.Modules.Orders.Services
{

    public class OrderPaymentService : IGenericService<OrderPayment>
    {
        private readonly OrderDbContext _context;
        private readonly DbSet<OrderPayment> _dbSet;

        public OrderPaymentService(OrderDbContext context)
        {
            _context = context;
            _dbSet = context.Set<OrderPayment>();
        }

        public async Task<OrderPayment?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<OrderPayment>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(OrderPayment orderPayment)
        {
            bool exists = await _dbSet.AnyAsync(o => o.TransactionNumber == orderPayment.TransactionNumber);

            if (exists)
                throw new InvalidOperationException("The discount code already exists.");

            await _dbSet.AddAsync(orderPayment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderPayment orderPayment)
        {
            if (orderPayment == null)
            {
                throw new ArgumentNullException(nameof(orderPayment), "Discount cannot be null.");
            }

            var currentOrderPayment = await GetByIdAsync(orderPayment.Id)
                ?? throw new ArgumentNullException(nameof(orderPayment), "No matching Discount was found.");

            _context.Entry(currentOrderPayment).CurrentValues.SetValues(orderPayment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderPayment = await GetByIdAsync(id);

            if (orderPayment != null)
            {
            _dbSet.Remove(orderPayment);
            }
        }
    }
}
