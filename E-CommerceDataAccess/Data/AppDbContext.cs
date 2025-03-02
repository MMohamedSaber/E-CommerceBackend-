using E_CommerceBuisnessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace E_CommerceDataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BestSelling> bestSellings { get; set; }
        public DbSet<User> users{ get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }

}
