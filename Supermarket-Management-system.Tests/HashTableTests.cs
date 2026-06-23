    using Xunit;
    using Supermarket_Management_system.Core;
    using Microsoft.VisualBasic;

    namespace Supermarket_Management_system.Tests;

public class HashTableTests
{
    [Fact]
    public void Add_ThenGet_ReturnsStoredValue()
    {
        var table = new HashTable();
        var milk = new Product { Title = "Milk", Barcode = "12345" };
        table.Add("12345", milk);
        Product result = table.Get("12345");
        Assert.Equal(milk, result);
    }

    [Fact]
    public void Get_MissingKey_ReturnsNull()
    {
        var table = new HashTable();
        Product result = table.Get("99999");
        Assert.Null(result);
    }

    [Fact]
    public void Add_DuplicateKey_Throws()
    {
        var table = new HashTable();
        table.Add("12345", new Product { Title = "Milk" });
        Assert.Throws<Exception>(() => table.Add("12345", new Product { Title = "Bread" }));
    }

    [Fact]
    public void Add_MultipleItems_AllRetrievable()
    {
        var table = new HashTable();
        table.Add("111", new Product { Title = "Apple" });
        table.Add("222", new Product { Title = "Bread" });
        table.Add("333", new Product { Title = "Cola" });

         Assert.Equal("Apple", ((Product)table.Get("111")).Title);
         Assert.Equal("Bread", ((Product)table.Get("222")).Title);
         Assert.Equal("Cola", ((Product)table.Get("333")).Title);
    }
    [Fact]
    public void Remove_ThenGet_ReturnsNull()
    {
        var table = new HashTable();
        table.Add("111", new Product { Title = "Apple" });

        table.Remove("111");

        Assert.Null(table.Get("111"));
    }
}

