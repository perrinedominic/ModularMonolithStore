using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common;
using ModularMonolithStore.Modules.Products.Data;
using ModularMonolithStore.Modules.Products.Models;
using ModularMonolithStore.Modules.Products.Repositories;
using ModularMonolithStore.Modules.Products.Services.Interfaces;

namespace ModularMonolithStore.Modules.Products.Services
{

    public class ProductReviewService : IGenericService<ProductReview>
    {
        private readonly IGenericRepository<ProductReview> _productReviewRepository;

        public ProductReviewService(IGenericRepository<ProductReview> productReviewRepository)
        {
            _productReviewRepository = productReviewRepository;
        }

        public async Task<ProductReview?> GetByIdAsync(int id)
        {
            return await _productReviewRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProductReview>> GetAllAsync()
        {
            return await _productReviewRepository.GetAllAsync();
        }

        public async Task AddAsync(ProductReview productReview)
        {
            var productReviews = await GetAllAsync();
            bool exists = productReviews.Any(p => p.CustomerId == productReview.CustomerId && p.ProductId == productReview.ProductId);

            if (exists)
                throw new InvalidOperationException("The customer has already left a review on this product.");

            await _productReviewRepository.AddAsync(productReview);
            await _productReviewRepository.SaveAsync();
        }

        public async Task UpdateAsync(ProductReview productReview)
        {
            if (productReview == null)
            {
                throw new ArgumentNullException(nameof(productReview), "Review cannot be null.");
            }

            var currentProductBrand = await GetByIdAsync(productReview.Id)
                ?? throw new ArgumentNullException(nameof(productReview), "No matching Review was found.");

            await _productReviewRepository.UpdateAsync(productReview);
            await _productReviewRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productReview = await GetByIdAsync(id);

            if (productReview != null)
            {
                await _productReviewRepository.DeleteAsync(productReview);
            }
        }
    }
}
