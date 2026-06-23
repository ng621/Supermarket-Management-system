 using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public List<Stock> GetLowStockItems()
        {
            List<Stock> lowStock = new List<Stock>();

            using (var context = new SupermarketContext())
            {
                List<Stock> allStock = context.Stocks.Include(s => s.Product).ToList();
                foreach (Stock s in allStock)
                {
                    if (s.QuantityInStock <= s.ReorderLevel) lowStock.Add(s);
                }
            }
            return lowStock;
        }
        public string RecordSale(string barcode, int quantitySold)
        {
            Product product = barcodeIndex.Get(barcode);

            if (product == null)
            {
                return "No product with that barcode";
            }
            if (quantitySold <= 0) 
            {
                return "Quantity must be positive";
            }
            using (var context = new SupermarketContext())
            {
                Stock stock = context.Stocks.FirstOrDefault(s => s.ProductId == product.ProductId);

                if (stock == null) 
                {
                    return "No stock record for that product";
                }
                if (stock.QuantityInStock < quantitySold)
                {
                    return "Not enough stock. Only " + stock.QuantityInStock + " left.";
                }
                var sale = new Sale
                {
                    SaleDate = DateTime.Now,
                    TotalAmount = product.Price * quantitySold
                };
                context.Sales.Add(sale);
                context.SaveChanges();


                var item = new SaleItem
                {
                    SaleId = sale.SaleId,
                    ProductId = product.ProductId,
                    Quantity = quantitySold,
                    UnitPrice = product.Price,
                };
                context.SaleItems.Add(item);

                stock.QuantityInStock = stock.QuantityInStock - quantitySold;

                context.SaveChanges();
            }
            return null;
           
        }
    }
}
