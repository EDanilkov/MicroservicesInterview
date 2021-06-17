using Product.Model;
using System;
using System.Threading.Tasks;

namespace Product.Data.Repositories.Abstracts
{
    public interface IProductRepository
    {
        Task<ProductModel> GetProductByProductIdAsync(Guid productId);

        Task<ProductModel> AddProductAsync(string productName);
    }
}
