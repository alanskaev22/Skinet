using Core.Entities;
using Core.Interfaces;
using Infrastructre.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _storeContext.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _storeContext.Products
                .Include(product => product.ProductBrand)   //We need to tell ef to return these objects as well, otherwise
                .Include(product => product.ProductType)    //these objects will be null in api response
                .FirstOrDefaultAsync(product => product.Id == id); //Predicate to match the id
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _storeContext.Products
                .Include(product => product.ProductBrand)   //We need to tell ef to return these objects as well, otherwise
                .Include(product => product.ProductType)    //these objects will be null in api response
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _storeContext.ProductTypes.ToListAsync();
        }
    }
}
