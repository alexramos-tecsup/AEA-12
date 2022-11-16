using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstDemo.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }

        public double Price { get; set;}

        public int SellerID { get; set; }
        public Seller Seller { get; set; }


        public List<Invoice> Invoices { get; set; }
    }
}