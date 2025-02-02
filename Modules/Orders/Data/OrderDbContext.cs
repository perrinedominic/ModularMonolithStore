using Microsoft.EntityFrameworkCore;

namespace ModularMonolithStore.Modules.Orders.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options) { }

        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.OrderItem> OrderItems { get; set; }
        public DbSet<Models.OrderPayment> OrderPayment { get; set; }
        public DbSet<Models.OrderShippingAddress> OrderShippingAddress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
