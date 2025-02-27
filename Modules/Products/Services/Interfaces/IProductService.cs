﻿using Web.Core.Modules.Products.Models;

namespace Web.Core.Modules.Products.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetByBrandAsync(int brandId);
        Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetByTagAsync(int tagId);
        Task<IEnumerable<Product>> GetByDiscountAsync(int tagId);
    }
}
