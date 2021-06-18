using Microsoft.EntityFrameworkCore;

namespace User.Data.Context
{
    public class UserContext : DbContext
    {
        public DbSet<Models.User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
