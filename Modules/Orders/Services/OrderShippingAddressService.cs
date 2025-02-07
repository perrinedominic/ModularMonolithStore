using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common;
using ModularMonolithStore.Modules.Orders.Data;
using ModularMonolithStore.Modules.Orders.Models;

namespace ModularMonolithStore.Modules.Orders.Services
{

    public class OrderShippingAddressService : IGenericService<OrderShippingAddress>
    {
        private readonly IGenericRepository<OrderShippingAddress> _orderShippingAddressRepository;

        public OrderShippingAddressService(IGenericRepository<OrderShippingAddress> orderShippingAddressRepository)
        {
            _orderShippingAddressRepository = orderShippingAddressRepository;
        }

        public async Task<OrderShippingAddress?> GetByIdAsync(int id)
        {
            return await _orderShippingAddressRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<OrderShippingAddress>> GetAllAsync()
        {
            return await _orderShippingAddressRepository.GetAllAsync();
        }

        public async Task AddAsync(OrderShippingAddress orderShippingAddress)
        {
            await _orderShippingAddressRepository.AddAsync(orderShippingAddress);
            await _orderShippingAddressRepository.SaveAsync();
        }

        public async Task UpdateAsync(OrderShippingAddress orderShippingAddress)
        {
            var currentOrderShippingAddress = await GetByIdAsync(orderShippingAddress.Id)
                ?? throw new ArgumentNullException(nameof(orderShippingAddress), "No matching Shipping Address was found.");

            await _orderShippingAddressRepository.UpdateAsync(currentOrderShippingAddress);
            await _orderShippingAddressRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderShippingAddress = await GetByIdAsync(id);

            if (orderShippingAddress != null)
            {
                await _orderShippingAddressRepository.DeleteAsync(orderShippingAddress);
            }

            await _orderShippingAddressRepository.SaveAsync();
        }
    }
}
