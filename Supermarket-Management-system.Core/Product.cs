namespace Supermarket_Management_system.Core
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}