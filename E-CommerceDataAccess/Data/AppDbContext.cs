using E_CommerceDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace E_CommerceDataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Categori> categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }

}
