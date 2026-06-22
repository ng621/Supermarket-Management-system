    using Xunit;
    using Supermarket_Management_system.Core;
    using Microsoft.VisualBasic;

    namespace Supermarket_Management_system.Tests;

    public class HashTableTests
    {
        [Fact]
        public void Test1()
        {
            var table = new HashTable();

            table.Add("12345", "Milk");
            string result = table.Get("12345");

            Assert.Equal("Milk", result);
        }
    [Fact]
    public void Get_MissingKey_ReturnsNull()
    {
        var table = new HashTable();

        string result = table.Get("99999");

        Assert.Null(result);
    }

    [Fact]
    public void Add_DuplicateKey_ThrowsException()
    {
        var table = new HashTable();

        table.Add("12345", "Milk");

        Assert.Throws<Exception>(() => table.Add("12345", "Bread"));
    }
}
