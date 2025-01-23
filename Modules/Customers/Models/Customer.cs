using ModularMonolithStore.Modules.Orders.Models;

namespace ModularMonolithStore.Modules.Customers.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }   
        public required string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<CustomerAddress> Addresses { get; set; }
    }
}
