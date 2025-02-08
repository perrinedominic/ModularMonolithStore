using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Orders.Data;
using Web.Core.Modules.Orders.Models;

namespace Web.Core.Modules.Orders.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderPaymentRepository : IGenericRepository<OrderPayment>
    {
        private readonly OrderDbContext _context;
        private readonly DbSet<OrderPayment> _dbSet;

        public OrderPaymentRepository(OrderDbContext context)
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
            await _dbSet.AddAsync(orderPayment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderPayment orderPayment)
        {
            _dbSet.Update(orderPayment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(OrderPayment orderPayment)
        {
            if (orderPayment != null)
            {
                _dbSet.Remove(orderPayment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
