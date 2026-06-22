using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket_Management_system.Core
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
