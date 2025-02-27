﻿using Microsoft.EntityFrameworkCore;
using Web.Core.Common;
using Web.Core.Modules.Products.Data;
using Web.Core.Modules.Products.Models;
using Web.Core.Modules.Products.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Web.Core.Modules.Products.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductRepository : IProductRepository, IGenericRepository<Product>
    {
        private readonly ProductDbContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Product>();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// Adds a new product to the database. Checks if a product with the same name and brand already exists.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// If the product name is not unique within a specific brand, alert the user.
        /// </exception>
        public async Task AddAsync(Product product)
        {
            await _dbSet.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _dbSet.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            if (product != null)
            {
                _dbSet.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetByBrandAsync(int brandId)
        {
            return await _dbSet.Where(p => p.Brand.Id == brandId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
        {
            return await _dbSet.Where(p => p.Category.Id == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByTagAsync(int tagId)
        {
            return await _dbSet.Where(p => p.Tag.Id == tagId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByDiscountAsync(int discountId)
        {
            return await _dbSet.Where(p => p.Discount.Id == discountId).ToListAsync();
        }


        public Task<IQueryable<Product>> GetByExAsync(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
