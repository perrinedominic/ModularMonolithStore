using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Orders.Data;
using Web.Core.Modules.Orders.Models;
using Web.Core.Modules.Products.Services.Interfaces;

namespace Web.Core.Modules.Orders.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderService : IGenericService<Order>, IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public OrderService(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task AddAsync(Order order)
        {
            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Brand cannot be null.");
            }

            var currentOrderBrand = await GetByIdAsync(order.Id)
                ?? throw new ArgumentNullException(nameof(order), "No matching Brand was found.");

            _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderService = await GetByIdAsync(id);

            if (orderService != null)
            {
                await _orderRepository.DeleteAsync(orderService);
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
