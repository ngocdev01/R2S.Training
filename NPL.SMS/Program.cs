using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2S.Training.Entities;
using R2S.Training.DAO;

namespace R2S.Training
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDAO daoProcduct = new ProductDAO();
            CustomerDAO daoCustomer = new CustomerDAO();
            OrderDAO daoOrder= new OrderDAO();
            LineItemDAO daoLineItem = new LineItemDAO();

            List<Product> liProduct = daoProcduct.GetAllProduct();
            List<Customer> liCustomer = daoCustomer.GetAllCustomer(null,null,"customer_name");
            List<Order> liOrder= daoOrder.GetAllOrderByCustomerId("customer_id", "3");
            List<LineItem> liLine = daoLineItem.GetAllItemsByOrderId("order_id","2");

            if(liProduct!=null)
                foreach(Product product in liProduct)
                {
                    Console.WriteLine(product.ToString());
               
                }
            if (liCustomer != null)
                foreach (Customer customer in liCustomer)
                {
                    Console.WriteLine(customer.ToString());

                }
            if (liOrder != null)
                foreach (Order order in liOrder)
                {
                    Console.WriteLine(order.OderDate);

                }
             if (liLine != null)
                foreach (LineItem line in liLine)
                {
                    Console.WriteLine(line.ToString());

                }
            Console.ReadKey();
            string error = "";
            Customer cs = new Customer();
            cs.CustomerName = "Ngoccc";
            cs.CustomerId =18 ;

            /*if (!dao1.InsertCustomer(cs, ref error))
                Console.WriteLine(error);
            Console.ReadLine();*/
            
            /*if (!dao1.DeleteCustomer(cs, ref error))
                Console.WriteLine(error);
            Console.WriteLine("Delete done");*/

            /*if (!daoCustomer.UpdateCustomer(cs, ref error))
                Console.WriteLine(error);
            Console.WriteLine("Update done");

            LineItem lineitem = new LineItem();
            lineitem.OrderId =1;
            double total_order= daoLineItem.ComputeOrderTotal(lineitem);
            Console.WriteLine("total price {0}",total_order);
            Console.ReadKey();*/
        }
    }
}
