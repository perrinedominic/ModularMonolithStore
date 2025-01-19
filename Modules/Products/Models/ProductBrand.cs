namespace ModularMonolithStore.Modules.Products.Models
{
    public class ProductBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        public string ContryOfOrigin { get; set; }
        // Navigation property
        public ICollection<Product> Products { get; set; }
    }
}
