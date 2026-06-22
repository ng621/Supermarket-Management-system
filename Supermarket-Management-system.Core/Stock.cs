using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket_Management_system.Core
{
    public class Stock
    {
        public int StockId { get; set; }
        public int QuantityInStock { get; set; }
        public int ReorderLevel { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
