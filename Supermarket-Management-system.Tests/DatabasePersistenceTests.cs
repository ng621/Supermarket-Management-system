using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Supermarket_Management_system.Core;

namespace Supermarket_Management_system.Tests
{
    public class DatabasePersistenceTests
    { 
        private SupermarketContext NewInMemoryContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<SupermarketContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
            return new SupermarketContext(options);
        }

        [Fact]
        public void Product_SavedToDatabase_CanBeReadBack()
        {
             using (var context = NewInMemoryContext("test_save_read"))
            {
                var product = new Product { Title = "Test Milk", Barcode = "999", Price = 1.50m };
                context.Products.Add(product);
                context.SaveChanges();
            }

             using (var context = NewInMemoryContext("test_save_read"))
            {
                Product loaded = context.Products.FirstOrDefault(p => p.Barcode == "999");

                 Assert.NotNull(loaded);
                 Assert.Equal("Test Milk", loaded.Title);
            }
        }
    }
}