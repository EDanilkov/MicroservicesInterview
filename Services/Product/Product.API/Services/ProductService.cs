using Product.API.Services.Abstracts;
using Product.Data.Repositories.Abstracts;
using Product.Model;
using System;
using System.Threading.Tasks;

namespace Product.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductModel> GetProductByProductIdAsync(Guid productId)
        {
            return await _productRepository.GetProductByProductIdAsync(productId);
        }

        /// <summary>
        /// Create a product with Name = name
        /// </summary>
        /// <returns></returns>
        public async Task<ProductModel> AddProductAsync(string productName)
        {
            return await _productRepository.AddProductAsync(productName);
        }
    }
}
