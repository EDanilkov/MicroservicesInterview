using Microsoft.EntityFrameworkCore;
using Product.Data.Context;
using Product.Data.Repositories.Abstracts;
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
        public async Task<Models.Product> GetProductByProductIdAsync(Guid productId)
        {
            return await _productContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        /// <summary>
        /// Create a product with Name = name
        /// </summary>
        /// <returns></returns>
        public async Task<Models.Product> AddProductAsync(string productName)
        {
            var product = new Models.Product()
            {
                Name = productName,
                CreationDate = DateTime.Now
            };
            await _productContext.Products.AddAsync(product);
            await _productContext.SaveChangesAsync();

            return product;
        }
    }
}
