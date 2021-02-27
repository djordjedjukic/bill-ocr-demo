using System;
using System.Collections.Generic;

namespace TestOCR.Models
{
    public class Bill
    {
        public string Store { get; set; }
        
        public DateTime PurchaseDate { get; set; }
        
        public string Price { get; set; }

        public string PaymentType { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }

    public class Product
    {
        public string Name { get; set; }

        public int Amount { get; set; }

        public string Price { get; set; }
    }
}