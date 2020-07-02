using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Core.Interfaces;
using Infrastrcture.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericsRepository<Product> _productRepo;
        private readonly IGenericsRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericsRepository<ProductType> _productTypeRepo;

        public ProductController(IGenericsRepository<Product> productRepo, IGenericsRepository<ProductBrand> productBrandRepo, IGenericsRepository<ProductType> productTypeRepo)
        {
            _productRepo = productRepo;
           _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productRepo.ListAllAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {

            return await _productRepo.GetByIdAsync(id);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var ProductBrand = await _productBrandRepo.ListAllAsync();
            return Ok(ProductBrand);

        }
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var ProductType = await _productTypeRepo.ListAllAsync();
            return Ok(ProductType);
        }
    }
}
