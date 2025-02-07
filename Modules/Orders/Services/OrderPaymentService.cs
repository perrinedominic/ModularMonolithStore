using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common;
using ModularMonolithStore.Modules.Orders.Data;
using ModularMonolithStore.Modules.Orders.Models;

namespace ModularMonolithStore.Modules.Orders.Services
{

    public class OrderPaymentService : IGenericService<OrderPayment>
    {
        private readonly IGenericRepository<OrderPayment> _orderPaymentRepository;

        public OrderPaymentService(IGenericRepository<OrderPayment> orderPaymentRepository)
        {
            _orderPaymentRepository = orderPaymentRepository;
        }

        public async Task<OrderPayment?> GetByIdAsync(int id)
        {
            return await _orderPaymentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<OrderPayment>> GetAllAsync()
        {
            return await _orderPaymentRepository.GetAllAsync();
        }

        public async Task AddAsync(OrderPayment orderPayment)
        {
            await _orderPaymentRepository.AddAsync(orderPayment);
            await _orderPaymentRepository.SaveAsync();
        }

        public async Task UpdateAsync(OrderPayment orderPayment)
        {
            if (orderPayment == null)
            {
                throw new ArgumentNullException(nameof(orderPayment), "Discount cannot be null.");
            }

            var currentOrderPayment = await GetByIdAsync(orderPayment.Id)
                ?? throw new ArgumentNullException(nameof(orderPayment), "No matching Discount was found.");

            await _orderPaymentRepository.UpdateAsync(orderPayment);
            await _orderPaymentRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderPayment = await GetByIdAsync(id);

            if (orderPayment != null)
            {
                await _orderPaymentRepository.DeleteAsync(orderPayment);
            }
        }
    }
}
