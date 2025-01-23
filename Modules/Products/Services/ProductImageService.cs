﻿using Microsoft.EntityFrameworkCore;
using ModularMonolithStore.Common.Interfaces;
using ModularMonolithStore.Modules.Products.Data;
using ModularMonolithStore.Modules.Products.Models;

namespace ModularMonolithStore.Modules.Products.Services
{

    public class ProductImageService : IGenericService<ProductImage>
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<ProductImage> _dbSet;

        public ProductImageService(ProductDbContext context)
        {
            _context = context;
            _dbSet = context.Set<ProductImage>();
        }

        public async Task<ProductImage?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<ProductImage>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(ProductImage ProductImage)
        {
            await _dbSet.AddAsync(ProductImage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductImage ProductImage)
        {
            if (ProductImage == null)
            {
                throw new ArgumentNullException(nameof(ProductImage), "Discount cannot be null.");
            }

            var currentProductBrand = await GetByIdAsync(ProductImage.Id)
                ?? throw new ArgumentNullException(nameof(ProductImage), "No matching Discount was found.");

            _context.Entry(currentProductBrand).CurrentValues.SetValues(ProductImage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ProductImage = await GetByIdAsync(id);

            if (ProductImage != null)
            {
            _dbSet.Remove(ProductImage);
            }
        }
    }
}
