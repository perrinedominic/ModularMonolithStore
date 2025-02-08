using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Orders.Data;
using Web.Core.Modules.Orders.Models;
using Web.Core.Modules.Orders.Repositories.Interfaces;

namespace Web.Core.Modules.Orders.Repositories
{

    public class OrderRepository : IOrderRepository, IGenericRepository<Order>
    {
        private readonly OrderDbContext _context;
        private readonly DbSet<Order> _dbSet;

        public OrderRepository(OrderDbContext context)
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
            await _dbSet.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _dbSet.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            if (order != null)
            {
                _dbSet.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Order>> GetByBrandAsync(int brandId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetByTagAsync(int tagId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetByDiscountAsync(int tagId)
        {
            throw new NotImplementedException();
        }
    }
}
