using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common;
using ModularMonolithStore.Modules.Products.Data;
using ModularMonolithStore.Modules.Products.Models;
using ModularMonolithStore.Modules.Products.Repositories.Interfaces;
using ModularMonolithStore.Modules.Products.Services.Interfaces;

namespace ModularMonolithStore.Modules.Products.Services
{
    public class ProductBrandService : IGenericService<ProductBrand>
    {
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;


        public ProductBrandService(IGenericRepository<ProductBrand> productBrandRepository)
        {
            _productBrandRepository = productBrandRepository;
        }

        public async Task<ProductBrand?> GetByIdAsync(int id)
        {
            return await _productBrandRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProductBrand>> GetAllAsync()
        {
            return await _productBrandRepository.GetAllAsync();
        }

        public async Task AddAsync(ProductBrand productBrand)
        {
            var productBrands = await _productBrandRepository.GetAllAsync();
            bool exists = productBrands.Any(p => p.Name == productBrand.Name);

            if (exists)
                throw new InvalidOperationException("A brand with the same name already exists.");

            await _productBrandRepository.AddAsync(productBrand);
            await _productBrandRepository.SaveAsync();
        }

        public async Task UpdateAsync(ProductBrand productBrand)
        {
            if (productBrand == null)
            {
                throw new ArgumentNullException(nameof(productBrand), "Brand cannot be null.");
            }

            var currentProductBrand = await GetByIdAsync(productBrand.Id)
                ?? throw new ArgumentNullException(nameof(productBrand), "No matching Brand was found.");

            await _productBrandRepository.UpdateAsync(currentProductBrand);
            await _productBrandRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productBrand = await GetByIdAsync(id);

            if (productBrand != null)
            {
                await _productBrandRepository.DeleteAsync(productBrand);
            }
        }
    }
}
