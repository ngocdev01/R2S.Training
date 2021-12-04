using R2S.Training.DAO;
using R2S.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Main
{
    class SaleManagement
    {
        public static void Menu()
        {
            Console.WriteLine("###############################MENU###############################" +
                "\n1. Get Customer List." +
                "\n2. Get All Order By Customer Id." +
                "\n3. Get All Item By Order Id." +
                "\n4. Compute Order Total." +
                "\n5. Add Customer." +
                "\n6. Delete Customer." +
                "\n7. Update Customer." +
                "\n8. Add Order." +
                "\n9. Add LineItem." +
                "\n10. Update Order Total." +
                "\n11. Exit.");
        }

        public static void ExecuteUserChoose()
        {
            //Gọi lại Menu
            Menu();

            //Khai báo trước 3 đối tượng
            CustomerDAO customerDAO = new CustomerDAO();
            OrderDAO orderDAO = new OrderDAO();
            LineItemDAO lineItemDAO = new LineItemDAO();

            //Yêu cầu nhập lựa chọn
            Console.Write("Please select from 1 to 11: ");
            string choose = Console.ReadLine();

            //Thực hiện Menu
            //Gọi để in lại Menu
            Menu();

            //Chia trường hợp theo 10 lựa chọn
            switch (choose)
            {
                case "1": //Get Customer List.
                    {
                        Console.Clear();

                        //Gán danh sách customer và danh sách customerList
                        List<Customer> customerList = customerDAO.GetAllCustomer();

                        //In danh sách, nếu danh sách rống in empty
                        if (customerList != null)
                            foreach (Customer customer in customerList)
                            {
                                Console.WriteLine(customer.ToString());
                            }
                        else
                            Console.WriteLine("List is empty!");
                        break;
                    }
                case "2": //Get All Order By Customer Id
                    {
                        Console.Clear();

                        //Nhập customer id
                        Console.Write("Hay nhap CustomerId: ");
                        int customerId = Convert.ToInt32(Console.ReadLine());

                        //Gán danh sách order by customer và danh sách OrderByCustomerList
                        List<Order> OrderByCustomerList = orderDAO.GetAllOrderByCustomerId("customer_id", customerId.ToString());

                        //In danh sách, nếu danh sách rống in empty
                        if (OrderByCustomerList != null)
                            foreach (Order order in OrderByCustomerList)
                            {
                                Console.WriteLine(order.ToString());
                            }
                        else
                            Console.WriteLine("List is empty!");
                        break;
                    }
                case "3": //Get All Item By Order Id
                    {
                        Console.Clear();

                        //Nhập order id
                        Console.Write("Hay nhap OrderId: ");
                        int orderId = Convert.ToInt32(Console.ReadLine());

                        //Gán danh sách các item tìm bởi order id vào danh sách OrderByCustomerList
                        List<LineItem> ItemByOrderIdList = lineItemDAO.GetAllItemsByOrderId("order_id", orderId.ToString());

                        //In danh sách, nếu danh sách rống in empty
                        if (ItemByOrderIdList != null)
                            foreach (LineItem item in ItemByOrderIdList)
                            {
                                Console.WriteLine(item.ToString());
                            }
                        else
                            Console.WriteLine("List is empty!");
                        break;
                    }
                case "4": //Compute Order Total
                    {
                        Console.Clear();

                        //Tạo đối tượng lineItem
                        LineItem lineItem = new LineItem();

                        //Nhập order id
                        Console.Write("Hay nhap OrderId: ");
                        lineItem.OrderId = Convert.ToInt32(Console.ReadLine());

                        //In ra giá trị compute được của order id đó
                        Console.Write("Total price: " + lineItemDAO.ComputeOrderTotal(lineItem));
                        break;
                    }
                case "5": //Add Customer
                    {

                        Console.Clear();

                        Customer customer = new Customer();

                        //##############Nhập thuộc tính của đối tượng customer##############

                        // Nhập customer name
                        Console.Write("Hay nhap CustomerName: ");
                        customer.CustomerName = Console.ReadLine();

                        //Truyền đối tượng customer vào pt AddCustomer của CustomerDAO
                        String error = "";
                        customerDAO.AddCustomer(customer, ref error);

                        //Check có error xảy ra không
                        if (error != "")
                        {
                            Console.Clear();
                            Console.WriteLine("Error: " + error);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Add success!!");
                        }
                        break;
                    }
                case "6": //Delete Customer
                    {
                        Console.Clear();

                        Customer customer = new Customer();

                        //##############Nhập thuộc tính của đối tượng customer##############

                        // Nhập customer id 
                        Console.Write("Hay nhap CustomeId: ");
                        customer.CustomerId = Convert.ToInt32(Console.ReadLine());

                        //Truyền đối tượng customer vào pt DeleteCustomer của CustomerDAO
                        String error = "";
                        customerDAO.DeleteCustomer(customer, ref error);

                        //Check có error xảy ra không
                        if (error != "")
                        {
                            Console.Clear();
                            Console.WriteLine("Error: " + error);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Delete success!!");
                        }
                        break;
                    }
                case "7": //Update Customer
                    {
                        Console.Clear();

                        Customer customer = new Customer();

                        //##############Nhập các thuộc tính của đối tượng customer##############

                        // Nhập customer id 
                        Console.Write("Hay nhap CustomeId can cap nhat: ");
                        customer.CustomerId = Convert.ToInt32(Console.ReadLine());

                        // Nhập customer name
                        Console.Write("Hay nhap CustomerName moi: ");
                        customer.CustomerName = Console.ReadLine();

                        //Truyền đối tượng customer vào pt DeleteCustomer của CustomerDAO
                        String error = "";
                        customerDAO.UpdateCustomer(customer, ref error);

                        //Check có error xảy ra không
                        if (error != "")
                        {
                            Console.Clear();
                            Console.WriteLine("Error: " + error);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Update success!!");
                        }
                        break;
                    }
                case "8": // Add order
                    {
                        Console.Clear();

                        Order order = new Order();

                        //##############Nhập các thuộc tính của đối tượng order##############
                        //Nhập ngày
                        byte ngay;
                        Console.Write("Hay nhap ngay: ");
                        ngay = Convert.ToByte(Console.ReadLine());

                        //Nhập tháng
                        byte thang;
                        Console.Write("Hay nhap thang: ");
                        thang = Convert.ToByte(Console.ReadLine());

                        //Nhập năm
                        ushort nam;
                        Console.Write("Hay nhap nam: ");
                        nam = Convert.ToUInt16(Console.ReadLine());

                        //Tạo đối tượng datetime và khởi tạo nó với ngày tháng năm vừa nhập
                        DateTime orderDate = new DateTime(nam, thang, ngay);
                        //Gán đối tượng datetime vừa tạo cho thuộc tính orderDate của order
                        order.OderDate = orderDate;

                        //Nhập customer id
                        Console.Write("Hay nhap CustomerId: ");
                        order.CustomerId = Convert.ToInt32(Console.ReadLine());

                        // Nhập employee id
                        Console.Write("Hay nhap EmployeeId: ");
                        order.EmployeeId = Convert.ToInt32(Console.ReadLine());

                        //Truyền đối tượng order vào pt Addorder của orderDAO
                        String error = "";
                        orderDAO.AddOrder(order, ref error);

                        //Check có error xảy ra không
                        if (error != "")
                        {
                            Console.Clear();
                            Console.WriteLine("Error: " + error);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Add success!!");
                        }
                        break;
                    }
                case "9": //Add lineitem
                    {
                        Console.Clear();

                        LineItem lineItem = new LineItem();

                        //##############Nhập các thuộc tính của đối tượng lineItem##############
                        //Nhâp order id
                        Console.Write("Hay nhap OrderId: ");
                        lineItem.OrderId = Convert.ToInt32(Console.ReadLine());

                        //Nhập product id
                        Console.Write("Hay nhap ProductId: ");
                        lineItem.ProductId = Convert.ToInt32(Console.ReadLine());

                        //Nhập quantity
                        Console.Write("Hay nhap Quantity: ");
                        lineItem.Quantity = Convert.ToInt32(Console.ReadLine());

                        //Nhập price
                        Console.Write("Hay nhap Price: ");
                        lineItem.Price = Convert.ToDouble(Console.ReadLine());

                        //Truyền đối tượng lineItem vào pt AddLineItem của LineItemDAO
                        String error = "";
                        lineItemDAO.AddLineItem(lineItem, ref error);

                        //Check có error xảy ra không
                        if (error != "")
                        {
                            Console.Clear();
                            Console.WriteLine("Error: " + error);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Add success!!");
                        }
                        break;
                    }
                case "10": //Update order total
                    {
                        Console.Clear();

                        //Nhâp order id cần update
                        Console.Write("Hay nhap OrderId: ");
                        int orderId = Convert.ToInt32(Console.ReadLine());

                        String error = "";

                        //Truyền id vừa nhập vào pt update của orderDAO
                        orderDAO.UpdateOrderTotal(orderId, ref error);

                        //Check có error xảy ra không
                        if (error != "")
                        {
                            Console.Clear();
                            Console.WriteLine("Error: " + error);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Update success!!");
                        }
                        break;
                    }
                case "11": //Exit
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("\n\nIncorrect option. Press ESC to choose again!");
                        break;
                    }
            }

            //Bắt phím ESC
            while(true)
            {
                var key = Console.ReadKey(true);
                if (Convert.ToInt32(key.KeyChar) == 27) //Phím Esc mã 27
                {
                    Console.Clear();
                    ExecuteUserChoose();
                }
            }    
        }

        static void Main(string[] args)
        {
            ExecuteUserChoose();            
        }
    }
}

