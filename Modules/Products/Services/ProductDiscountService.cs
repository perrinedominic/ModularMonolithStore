using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Products.Data;
using Web.Core.Modules.Products.Models;
using Web.Core.Modules.Products.Services.Interfaces;

namespace Web.Core.Modules.Products.Services
{

    public class ProductDiscountService : IGenericService<ProductDiscount>
    {
        private readonly IGenericRepository<ProductDiscount> _productDiscountRepository;


        public ProductDiscountService(IGenericRepository<ProductDiscount> productDiscountRepository)
        {
            _productDiscountRepository = productDiscountRepository;
        }

        public async Task<ProductDiscount?> GetByIdAsync(int id)
        {
            return await _productDiscountRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProductDiscount>> GetAllAsync()
        {
            return await _productDiscountRepository.GetAllAsync();
        }

        public async Task AddAsync(ProductDiscount productDiscount)
        {
            var productDiscounts = await _productDiscountRepository.GetAllAsync();
            bool exists = productDiscounts.Any(p => p.DiscountCode == productDiscount.DiscountCode);

            if (exists)
                throw new InvalidOperationException("The discount code already exists.");

            await _productDiscountRepository.AddAsync(productDiscount);
            await _productDiscountRepository.SaveAsync();
        }

        public async Task UpdateAsync(ProductDiscount productDiscount)
        {
            if (productDiscount == null)
            {
                throw new ArgumentNullException(nameof(productDiscount), "Discount cannot be null.");
            }

            var currentProductBrand = await GetByIdAsync(productDiscount.Id)
                ?? throw new ArgumentNullException(nameof(productDiscount), "No matching Discount was found.");

            await _productDiscountRepository.UpdateAsync(productDiscount);
            await _productDiscountRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productDiscount = await GetByIdAsync(id);

            if (productDiscount != null)
            {
                await _productDiscountRepository.DeleteAsync(productDiscount);
            }
        }
    }
}
