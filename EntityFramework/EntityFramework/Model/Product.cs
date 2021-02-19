using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
