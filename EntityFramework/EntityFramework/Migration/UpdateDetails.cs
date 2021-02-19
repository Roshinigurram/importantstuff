using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.Migration
{
    public class UpdateDetails
    {
        public void UpdateProduct(int ProductId, string newProductName)
        {
            using (var context = new EntityContext())
            {
                var product1 = context.Productss.Where(d => d.ProductId == ProductId).FirstOrDefault();
                if (product1 != null)
                {
                    product1.ProductName = newProductName;
                    context.Entry(product1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                Console.WriteLine("process completed");
            }
        }
        public void UpdateOrder(int OrderId, string newOrderName, string newOrderLoc)
        {
            using (var context = new EntityContext())
            {
                var order1 = context.Orderss.Where(d => d.OrderId == OrderId).FirstOrDefault();
                if (order1 != null)
                {
                    order1.OrderName = newOrderName;
                    order1.OrderLoc = newOrderLoc;
                    context.Entry(order1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                Console.WriteLine("process completed");
            }
        }
    }
}
