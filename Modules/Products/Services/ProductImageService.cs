using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Products.Data;
using Web.Core.Modules.Products.Models;
using Web.Core.Modules.Products.Services.Interfaces;

namespace Web.Core.Modules.Products.Services
{

    public class ProductImageService : IGenericService<ProductImage>
    {
        private readonly IGenericRepository<ProductImage> _productImageRepository;


        public ProductImageService(IGenericRepository<ProductImage> productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<ProductImage?> GetByIdAsync(int id)
        {
            return await _productImageRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProductImage>> GetAllAsync()
        {
            return await _productImageRepository.GetAllAsync();
        }

        public async Task AddAsync(ProductImage ProductImage)
        {
            await _productImageRepository.AddAsync(ProductImage);
            await _productImageRepository.SaveAsync();
        }

        public async Task UpdateAsync(ProductImage ProductImage)
        {
            if (ProductImage == null)
            {
                throw new ArgumentNullException(nameof(ProductImage), "Discount cannot be null.");
            }

            var currentProductBrand = await GetByIdAsync(ProductImage.Id)
                ?? throw new ArgumentNullException(nameof(ProductImage), "No matching Discount was found.");

            await _productImageRepository.UpdateAsync(ProductImage);
            await _productImageRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ProductImage = await GetByIdAsync(id);

            if (ProductImage != null)
            {
               await _productImageRepository.DeleteAsync(ProductImage);
            }
        }
    }
}
