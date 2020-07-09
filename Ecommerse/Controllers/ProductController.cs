using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entity;
using Core.Interfaces;
using Core.Specification;
using Ecommerse.DTO;
using Ecommerse.Error;
using Ecommerse.Helpers;
using Infrastrcture.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerse.Controllers
{
   
    public class ProductController : BaseApiController
    {
        private readonly IGenericsRepository<Product> _productRepo;
        private readonly IGenericsRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericsRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductController(IGenericsRepository<Product> productRepo, IGenericsRepository<ProductBrand> productBrandRepo, IGenericsRepository<ProductType> productTypeRepo,IMapper mapper)
        {
            _productRepo = productRepo;
           _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams productSpecParams)
        {
            var spec = new ProductsWithTypesandBrandsSpecification(productSpecParams);
            var countspec=new ProductwithFiltersForCountSpecification(productSpecParams);
            var totalItems = await _productRepo.CountAsync(countspec);

            var products = await _productRepo.LisAsync(spec);
            var data=_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
            return Ok(new Pagination<ProductToReturnDto>(productSpecParams.PageIndex, productSpecParams.PageSize, totalItems, data));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesandBrandsSpecification(id);
            var product= await _productRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductToReturnDto>(product);
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
