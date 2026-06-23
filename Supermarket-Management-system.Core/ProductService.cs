 using System.Collections.Generic;
using System.Linq;

namespace Supermarket_Management_system.Core
{
    public class ProductService
    {
        private HashTable barcodeIndex;
        private BinarySearchTree nameIndex;

        public ProductService()
        {
            barcodeIndex = new HashTable();
            nameIndex = new BinarySearchTree();
        }


        public void LoadFromDatabase()
        {
            using (var context = new SupermarketContext())
            {
                List<Product> products = context.Products.ToList();

                foreach (Product p in products)
                {
                    barcodeIndex.Add(p.Barcode, p);
                    nameIndex.Insert(p.Title, p);
                }
            }
        }

        public Product FindByBarcode(string barcode)
        {
            return barcodeIndex.Get(barcode);
        }
        public Product FindByName(string name)
        {
            return nameIndex.Search(name);
        }
        public List<Product> GetAllSortedByName()
        {
            return nameIndex.InOrder();
        }

        public string AddProduct(Product product, int quantity, int reorderLevel)
        {
            if (barcodeIndex.Get(product.Barcode) != null)
            {
                return "A product with that barcode already exists";
            }

            if (string.IsNullOrWhiteSpace(product.Title))
            {
                return "Title is required.";
            }
            if (product.Price <= 0)
            {
                return "Price must be positive";
            }
            if (quantity <= 0)
            {
                return "Quantity cannot be negative";
            }

            using (var context = new SupermarketContext())
            {
                context.Products.Add(product);
                context.SaveChanges();

                var stock = new Stock
                {
                    ProductId = product.ProductId,
                    QuantityInStock = quantity,
                    ReorderLevel = reorderLevel
                };
                context.Stocks.Add(stock);
                context.SaveChanges();
            }

            barcodeIndex.Add(product.Barcode, product);
            nameIndex.Insert(product.Title, product);

            return null;
        }
    }
}
