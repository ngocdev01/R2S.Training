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
            ProductDAO dao = new ProductDAO();
            CustomerDAO dao1 = new CustomerDAO();
            OrderDAO dao2 = new OrderDAO();

            List<Product> li = dao.GetAllProduct();
            List<Customer> li1 = dao1.GetAllCustomer(null,null,"customer_name");
            List<Order> li2 = dao2.GetAllOrder("customer_id", "3");
            if(li!=null)
                foreach(Product product in li)
                {
                    Console.WriteLine(product.ToString());
               
                }
            if (li1 != null)
                foreach (Customer customer in li1)
                {
                    Console.WriteLine(customer.ToString());

                }
            if (li2 != null)
                foreach (Order order in li2)
                {
                    Console.WriteLine(order.OderDate);

                }

            string error = "";
            Customer cs = new Customer();
            cs.CustomerName = "Ngoc";
            if (!dao1.InsertCustomer(cs, ref error))
                Console.WriteLine(error);
            Console.ReadLine();
            
        }
    }
}
