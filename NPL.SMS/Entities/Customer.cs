using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Entities
{
    public class Customer : IConvert
    {
        int customerId;
        string customerName;

        public int CustomerId { get => customerId; set => customerId = value; }
        public string CustomerName { get => customerName; set => customerName = value; }

        public Customer()
        {
        }

        public Customer(int customerId, string customerName)
        {
            this.customerId = customerId;
            this.customerName = customerName;
        }

        public void ConvertToObject(DataRow dr)
        {
            CustomerId = dr.Field<int>(0);
            CustomerName = dr.Field<string>(1);
        }

        public override string ToString()
        {
            return "Customer ID: " + CustomerId + "\t\t\tCustomer Name: " + CustomerName;
        }
    }
}
