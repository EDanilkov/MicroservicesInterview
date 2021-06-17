using Microsoft.EntityFrameworkCore;
using Product.Data.Context;
using Product.Data.Repositories.Abstracts;
using Product.Model;
using System;
using System.Threading.Tasks;

namespace Product.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        /// <summary>
        /// Get a product with ProductId
        /// </summary>
        /// <returns></returns>
        public async Task<ProductModel> GetProductByProductIdAsync(Guid productId)
        {
            return await _productContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        /// <summary>
        /// Create a product with Name = name
        /// </summary>
        /// <returns></returns>
        public async Task<ProductModel> AddProductAsync(string productName)
        {
            var productDto = new ProductModel()
            {
                Name = productName,
                CreationDate = new DateTime()
            };
            var newProduct = await _productContext.Products.AddAsync(productDto);
            await _productContext.SaveChangesAsync();
            return newProduct.Entity;
        }
    }
}
