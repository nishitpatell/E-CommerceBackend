using E_CommerceBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceBackend.Data
{
    public class SqlDbContext : IdentityDbContext<ApiUser>
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
