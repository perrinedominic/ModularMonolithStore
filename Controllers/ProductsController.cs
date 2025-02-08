using Microsoft.AspNetCore.Mvc;
using Web.Core.Modules.Products.DTOs;
using Web.Core.Modules.Products.Models;
using Web.Core.Modules.Products.Services;
using Web.Core.Modules.Products.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Core.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<Product>> GetAllAsync()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task Post([FromBody] ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Price = productDto.Price,
                CreatedAt = DateTime.Now,
                LastModifiedAt = DateTime.Now,
            };

            await _productService.AddAsync(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async void Put(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Price = productDto.Price
            };

            await _productService.UpdateAsync(product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
