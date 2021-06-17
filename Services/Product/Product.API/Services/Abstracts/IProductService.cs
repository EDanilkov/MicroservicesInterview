using Product.Model;
using System;
using System.Threading.Tasks;

namespace Product.API.Services.Abstracts
{
    public interface IProductService
    {
        Task<ProductModel> GetProductByProductIdAsync(Guid productId);

        Task<ProductModel> AddProductAsync(string productName);
    }
}
