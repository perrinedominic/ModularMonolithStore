using System.ComponentModel.DataAnnotations;

namespace Web.Core.Modules.Products.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; } = String.Empty;

        public string SKU { get; set; } = String.Empty;

        public ProductBrand Brand { get; set; }

        [Required]
        [Range(0.01, 5000)]
        public decimal Price { get; set; }
        
        public ProductDiscount? Discount { get; set; }

        [Range(0, 100)]
        public int AvailableStock { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime LastModifiedAt { get; set; }
        
        public ProductCategory Category { get; set; }
        
        public ProductImage Image { get; set; }
        
        public ICollection<ProductReview> Reviews { get; set; }
        
        public ProductTag? Tag { get; set; }
    }
}
