using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Core.Modules.Orders.Models
{
    public class OrderPayment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public OrderPaymentStatus PaymentStatus { get; set; }

        [StringLength(4)]
        public string CVC { get; set; }

        [StringLength(100)]
        public string TransactionNumber { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public string CardNumber { get; set; }

        public string CardSecurityNumber { get; set; }

        public string CardHolderName { get; set; }

        public string CardExpiration { get; set; }

    }
}
