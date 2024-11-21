using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProductsApp.Data
{
    public class ProductsContext:IdentityDbContext<User>
    {
        IConfiguration configuration;

        public ProductsContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ProductsConnection"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
