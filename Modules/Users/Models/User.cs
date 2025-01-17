using ModularMonolithStore.Modules.Customers.Models;
using ModularMonolithStore.Modules.Orders.Models;

namespace ModularMonolithStore.Modules.Users.Models
{
    public class User
    {
        public int Id { get; set; }
        public string CognitoUserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public Customer Customer { get; set; }
    }
}
