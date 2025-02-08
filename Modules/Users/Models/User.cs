using Web.Core.Modules.Customers.Models;
using Web.Core.Modules.Orders.Models;

namespace Web.Core.Modules.Users.Models
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
