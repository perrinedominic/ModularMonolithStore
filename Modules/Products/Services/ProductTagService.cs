using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Products.Data;
using Web.Core.Modules.Products.Models;
using Web.Core.Modules.Products.Services.Interfaces;

namespace Web.Core.Modules.Products.Services
{

    public class ProductTagService : IGenericService<ProductTag>
    {
        private readonly IGenericRepository<ProductTag> _productTagRepository;


        public ProductTagService(IGenericRepository<ProductTag> productTagRepository)
        {
            _productTagRepository = productTagRepository;
        }

        public async Task<ProductTag?> GetByIdAsync(int id)
        {
            return await _productTagRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProductTag>> GetAllAsync()
        {
            return await _productTagRepository.GetAllAsync();
        }

        public async Task AddAsync(ProductTag productTag)
        {
            var productTags = await _productTagRepository.GetAllAsync();
            bool exists = productTags.Any(p => p.Name == productTag.Name);

            if (exists)
                throw new InvalidOperationException("A brand with the same name already exists.");

            await _productTagRepository.AddAsync(productTag);
            await _productTagRepository.SaveAsync();
        }

        public async Task UpdateAsync(ProductTag productTag)
        {
            if (productTag == null)
            {
                throw new ArgumentNullException(nameof(productTag), "Brand cannot be null.");
            }

            var currentProductBrand = await GetByIdAsync(productTag.Id)
                ?? throw new ArgumentNullException(nameof(productTag), "No matching Brand was found.");

            await _productTagRepository.UpdateAsync(productTag);
            await _productTagRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productTag = await _productTagRepository.GetByIdAsync(id);

            if (productTag != null)
            {
               await _productTagRepository.DeleteAsync(productTag);
            }
        }
    }
}
