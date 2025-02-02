using ModularMonolithStore.Modules.Orders.Models;
using ModularMonolithStore.Modules.Products.Models;

namespace ModularMonolithStore.Modules.Products.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetByOrderItemAsync(int orderItemId);
        Task<IEnumerable<Order>> GetByPaymentAsync(int categoryId);
        Task<IEnumerable<Order>> GetByShippingAddressAsync(int tagId);
    }
}
