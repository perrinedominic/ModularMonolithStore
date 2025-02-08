using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Orders.Data;
using Web.Core.Modules.Orders.Models;

namespace Web.Core.Modules.Orders.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderItemService : IGenericService<OrderItem>
    {
        private readonly IGenericRepository<OrderItem> _orderItemRepository;

        public OrderItemService(IGenericRepository<OrderItem> orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<OrderItem?> GetByIdAsync(int id)
        {
            return await _orderItemRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _orderItemRepository.GetAllAsync();
        }

        public async Task AddAsync(OrderItem orderItem)
        {
            await _orderItemRepository.AddAsync(orderItem);
            await _orderItemRepository.SaveAsync();
        }

        public async Task UpdateAsync(OrderItem orderItem)
        {
            if (orderItem == null)
            {
                throw new ArgumentNullException(nameof(orderItem), "Brand cannot be null.");
            }

            var currentOrderItem = await GetByIdAsync(orderItem.Id)
                ?? throw new ArgumentNullException(nameof(orderItem), "No matching Brand was found.");

            _orderItemRepository.UpdateAsync(orderItem);
            await _orderItemRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderItem = await GetByIdAsync(id);

            if (orderItem != null)
            {
               await _orderItemRepository.DeleteAsync(orderItem);
            }
        }
    }
}
