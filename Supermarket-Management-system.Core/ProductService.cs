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
    }
}
