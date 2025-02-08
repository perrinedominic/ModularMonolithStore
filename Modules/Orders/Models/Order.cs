using Web.Core.Modules.Customers.Models;
using Web.Core.Modules.Users.Models;
using System.ComponentModel.DataAnnotations;

namespace Web.Core.Modules.Orders.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Shipping { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderShippingAddress ShippingAddress { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Customer Customer { get; set; }
    }
}
