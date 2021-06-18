using System;
using System.Threading.Tasks;

namespace Product.Data.Repositories.Abstracts
{
    public interface IProductRepository
    {
        Task<Models.Product> GetProductByProductIdAsync(Guid productId);

        Task<Models.Product> AddProductAsync(string productName);
    }
}
