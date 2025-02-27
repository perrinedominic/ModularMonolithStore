﻿using Web.Core.Modules.Products.Models;
using System.ComponentModel.DataAnnotations;

namespace Web.Core.Modules.Products.DTOs
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
