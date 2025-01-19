namespace ModularMonolithStore.Modules.Products.Models
{
    public class ProductTag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
