namespace ModularMonolithStore.Modules.Products.Models
{
    public class ProductReview
    {
        // Review ID
        public int Id { get; set; }
        // Product Reference
        public int ProductId { get; set; }
        // Navigation Property
        public Product Product { get; set; }
        // Customer Reference
        public int CustomerId { get; set; }
        // Text of the review
        public string Review { get; set; }
        // Date of the review
        public DateTime CreatedAt { get; set; }
    }
}
