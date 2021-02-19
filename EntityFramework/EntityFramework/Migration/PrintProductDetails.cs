using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Migration
{
    public class PrintProductDetails
    {
        public void PrintProducts()
        {
            using (var context = new EntityContext())
            {
                var product1 = context.Productss;
                Console.WriteLine("*****************Product table*****************");
                foreach (var product2 in product1)
                {
                    Console.WriteLine(product2.ProductId + "  " + product2.ProductName);
                }
            }
        }
    }
}
