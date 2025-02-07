
using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common;
using ModularMonolithStore.Modules.Orders.Data;
using ModularMonolithStore.Modules.Products.Data;
using ModularMonolithStore.Modules.Products.Models;
using ModularMonolithStore.Modules.Products.Repositories;
using ModularMonolithStore.Modules.Products.Repositories.Interfaces;
using ModularMonolithStore.Modules.Products.Services;
using ModularMonolithStore.Modules.Products.Services.Interfaces;

namespace ModularMonolithStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Scan(scan => scan
                .FromAssemblyOf<IGenericRepository<object>>() // This will scan the assembly containing IGenericRepository
                .AddClasses(classes => classes.AssignableTo(typeof(IGenericRepository<>))) // Find all classes that implement IGenericRepository<T>
                .AsImplementedInterfaces() // Register them as their implemented interfaces (e.g., IGenericRepository<T>)
                .WithScopedLifetime() // Use scoped lifetime for repositories
            );

            // Automatically register all services that implement their respective interfaces
            builder.Services.Scan(scan => scan
                .FromAssemblyOf<IGenericService<object>>()  // This will scan the assembly containing your service interfaces
                .AddClasses(classes => classes.AssignableTo(typeof(IGenericService<>))) // Find all classes that implement IProductService
                .AsImplementedInterfaces()  // Register them as their implemented interfaces
                .WithScopedLifetime()  // Use scoped lifetime for services
            );

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
