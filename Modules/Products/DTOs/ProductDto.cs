using ModularMonolithStore.Modules.Products.Models;
using System.ComponentModel.DataAnnotations;

namespace ModularMonolithStore.Modules.Products.DTOs
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }
        public ProductBrand Brand { get; set; }
        [Range(0.01, 5000)]
        public decimal Price { get; set; }
    }
}
