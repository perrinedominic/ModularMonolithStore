namespace ModularMonolithStore.Modules.Products.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public ProductBrand Brand { get; set; }
        public decimal Price { get; set; }
        public ProductDiscount? DiscountedPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DateTime { get; set; }
        public ProductCategory Category { get; set; }
        public ProductImage Image { get; set; }
        public List<ProductReview> Reviews { get; set; }
        public ProductTag? Tag { get; set; }
    }
}
