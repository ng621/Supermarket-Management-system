using Microsoft.EntityFrameworkCore;

namespace Supermarket_Management_system.Core
{
    public class SupermarketContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier>Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=SupermarketDb;Trusted_Connection=True;");
        }
    }
}
