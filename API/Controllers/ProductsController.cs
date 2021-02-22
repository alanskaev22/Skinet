using Infrastructre.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;

        public ProductsController(IGenericRepository<Product> productsRepository,
                                  IGenericRepository<ProductBrand> productBrandRepository,
                                  IGenericRepository<ProductType> productTypeRepository)
        {
            _productsRepository = productsRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productsRepository.ListAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productsRepository.GetByIdAsync(id);
            return product;
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepository.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepository.ListAllAsync());
        }
    }
}
