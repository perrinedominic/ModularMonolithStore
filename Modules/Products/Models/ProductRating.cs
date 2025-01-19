namespace ModularMonolithStore.Modules.Products.Models
{
    public class ProductRating
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Stars { get; set; }
        public DateTime Date { get; set; }
    }
}
