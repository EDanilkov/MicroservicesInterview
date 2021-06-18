using AutoMapper;
using Product.API.Services.Abstracts;
using Product.Data.Repositories.Abstracts;
using Product.Model.ResponseModels;
using System;
using System.Threading.Tasks;

namespace Product.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductModel> GetProductByProductIdAsync(Guid productId)
        {
            var result = await _productRepository.GetProductByProductIdAsync(productId);

            return _mapper.Map<ProductModel>(result);
        }

        /// <summary>
        /// Create a product with Name = name
        /// </summary>
        /// <returns></returns>
        public async Task<ProductModel> AddProductAsync(string productName)
        {
            var result = await _productRepository.AddProductAsync(productName);

            return _mapper.Map<ProductModel>(result);
        }
    }
}
