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

            tree.Insert("Milk", "Milk 2L");
            string result = tree.Search("Milk");

            Assert.Equal("Milk 2L", result);
        }
        [Fact]
        public void Search_MissingName_ReturnsNull()
        {
            var tree = new BinarySearchTree();

            string result = tree.Search("Bread");

            Assert.Null(result);
        }
        [Fact]
        public void InOrder_ReturnsNamesAlphabetically()
        {
            var tree = new BinarySearchTree();
            tree.Insert("Sugar", "Sugar 1kg");
            tree.Insert("Apple", "Apple loose");
            tree.Insert("Milk", "Milk 2L");

            List<string> result = tree.InOrder();

            var expected = new List<string> { "Apple loose", "Milk 2L", "Sugar 1kg" };
            Assert.Equal(expected, result);
        }
    }
}
