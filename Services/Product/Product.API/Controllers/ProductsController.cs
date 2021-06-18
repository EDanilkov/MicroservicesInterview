using Microsoft.AspNetCore.Mvc;
using Product.API.Services.Abstracts;
using Product.Model.ResponseModels;
using System;
using System.Threading.Tasks;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get a product by productId
        /// </summary>
        /// <returns>Returns a product model object</returns>
        [HttpGet("{productId}")]
        [ProducesResponseType(typeof(ProductModel), 200)] //Success
        [ProducesResponseType(400)] //Bad Request
        [ProducesResponseType(404)] //Not Found
        [ProducesResponseType(500)] //Internal Server Error
        public async Task<IActionResult> GetProductByProductIdAsync(Guid productId)
        {
            var result = await _productService.GetProductByProductIdAsync(productId);

            return Ok(result);
        }

        /// <summary>
        /// Create a product with Name = name
        /// </summary>
        /// <returns></returns>
        [HttpPost("{productName}")]
        [ProducesResponseType(typeof(ProductModel), 200)] //Success
        [ProducesResponseType(400)] //Bad Request
        [ProducesResponseType(500)] //Internal Server Error
        public async Task<IActionResult> AddProductAsync(string productName)
        {
            var result = await _productService.AddProductAsync(productName);
            
            return Created("", result);
        }
    }
}
