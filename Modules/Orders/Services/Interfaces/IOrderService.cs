using Web.Core.Modules.Orders.Models;
using Web.Core.Modules.Products.Models;

namespace Web.Core.Modules.Products.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetByOrderItemAsync(int orderItemId);
        Task<IEnumerable<Order>> GetByPaymentAsync(int categoryId);
        Task<IEnumerable<Order>> GetByShippingAddressAsync(int tagId);
    }
}
