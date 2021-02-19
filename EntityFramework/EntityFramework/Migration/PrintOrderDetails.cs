using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Migration
{
    public class PrintOrderDetails
    {
        public void PrintOrders()
        {
            using (var context = new EntityContext())
            {
                var order1 = context.Orderss;
                Console.WriteLine("**************Order table*****************");
                foreach (var order2 in order1)
                {
                    Console.WriteLine(order2.OrderId + "  " + order2.OrderName + "  " + order2.OrderLoc);
                }
            }
        }
    }
}
