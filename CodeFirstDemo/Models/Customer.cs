using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstDemo.Models
{
    public class Customer
    {

        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Dni { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string Mail { get; set; }

        public string Phone { get; set; }


    }
}

