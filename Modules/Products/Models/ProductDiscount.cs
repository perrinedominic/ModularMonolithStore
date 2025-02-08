namespace Web.Core.Modules.Products.Models
{
    public class ProductDiscount
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DiscountCode { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
