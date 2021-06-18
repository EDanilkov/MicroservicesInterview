using Microsoft.EntityFrameworkCore;

namespace Product.Data.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<Models.Product> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
