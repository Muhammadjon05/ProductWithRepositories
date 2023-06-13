using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductWithRepositories.AppDbContext;
using ProductWithRepositories.Contracts;
using ProductWithRepositories.Entities;
using ProductWithRepositories.Models;

namespace ProductWithRepositories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController( IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
        {
            var product = await _productRepository.GetAllAsync();
            var productModel = product.Adapt<List<ProductModel>>();
            return Ok(productModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProduct(Guid id)
        {
            var product = await _productRepository.GetById(id);
            var productModel = product.Adapt<ProductModel>();
            return Ok(productModel);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> PutProduct(Product product)
        {
            await _productRepository.UpdateAsync(product);
            return Ok();
        }
        
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductModel product)
        {
            var model = product.Adapt<Product>();
            await _productRepository.AddAsync(model);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _productRepository.GetById(id);
            if (product is null)
            {
                return NotFound();
            }
            await _productRepository.DeleteAsync(id);
            return Ok();
        }

       
    }
}
