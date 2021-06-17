using Microsoft.EntityFrameworkCore;
using Product.Model;

namespace Product.Data.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options)
    : base(options)
        { }
    }
}
