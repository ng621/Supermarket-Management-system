using Xunit;
using System.Collections.Generic;
using Supermarket_Management_system.Core;

namespace Supermarket_Management_system.Tests
{
    public class BinarySearchTreeTests
    {
        [Fact]
        public void Insert_ThenSearch_ReturnsValue()
        {
            var tree = new BinarySearchTree();
            var milk = new Product { Title = "Milk", Barcode = "12345" };
            tree.Insert("Milk", milk);
            Product result = tree.Search("Milk");
            Assert.Equal(milk, result);
        }

        [Fact]
        public void Search_MissingName_ReturnsNull()
        {
            var tree = new BinarySearchTree();
            Product result = tree.Search("Bread");
            Assert.Null(result);
        }

        [Fact]
        public void InOrder_ReturnsNamesAlphabetically()
        {
            var tree = new BinarySearchTree();
            var sugar = new Product { Title = "Sugar" };
            var apple = new Product { Title = "Apple" };
            var milk = new Product { Title = "Milk" };
            tree.Insert("Sugar", sugar);
            tree.Insert("Apple", apple);
            tree.Insert("Milk", milk);
            List<Product> result = tree.InOrder();
            var expected = new List<Product> { apple, milk, sugar };
            Assert.Equal(expected, result);
        }
    }
}
