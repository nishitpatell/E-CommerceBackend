using E_CommerceBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceBackend.Data
{
    public class SqlDbContext : DbContext 
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Category { get; set; }
    }
}
