using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Products.Data;
using Web.Core.Modules.Products.Models;
using Web.Core.Modules.Products.Services.Interfaces;

namespace Web.Core.Modules.Products.Services
{

    public class ProductRatingService : IGenericService<ProductRating>
    {

        private readonly IGenericRepository<ProductRating> _productRatingRepository;

        public ProductRatingService(IGenericRepository<ProductRating> productRatingRepository)
        {
            _productRatingRepository = productRatingRepository;
        }

        public async Task<ProductRating?> GetByIdAsync(int id)
        {
            return await _productRatingRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProductRating>> GetAllAsync()
        {
            return await _productRatingRepository.GetAllAsync();
        }

        public async Task AddAsync(ProductRating productRating)
        {
            var productRatings = await GetAllAsync();
            bool exists = productRatings.Any(p => p.ProductId == productRating.ProductId && p.CustomerId == productRating.CustomerId);

            if (exists)
                throw new InvalidOperationException("The customer has already left a rating on this product.");

            await _productRatingRepository.AddAsync(productRating);
            await _productRatingRepository.SaveAsync();
        }

        public async Task UpdateAsync(ProductRating productRating)
        {
            if (productRating == null)
            {
                throw new ArgumentNullException(nameof(productRating), "Rating cannot be null.");
            }

            var currentProductBrand = await GetByIdAsync(productRating.Id)
                ?? throw new ArgumentNullException(nameof(productRating), "No matching Rating was found.");

            _productRatingRepository.UpdateAsync(productRating);
            await _productRatingRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productRating = await GetByIdAsync(id);

            if (productRating != null)
            {
               await _productRatingRepository.DeleteAsync(productRating);
            }
        }
    }
}
