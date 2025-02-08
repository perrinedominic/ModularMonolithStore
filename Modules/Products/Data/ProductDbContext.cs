using Microsoft.EntityFrameworkCore;
using Web.Core.Modules.Products.Models;
using Web.Core.Modules.Products.Repositories;

namespace Web.Core.Modules.Products.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductDiscount> ProductDiscount { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
    }
}
