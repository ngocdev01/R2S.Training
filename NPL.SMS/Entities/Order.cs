using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Entities
{
    public class Order : IConvert
    {
        int orderId;
        DateTime oderDate;
        int customerId;
        int employeeId;
        double total;

        public int OrderId { get => orderId; set => orderId = value; }
        public DateTime OderDate { get => oderDate; set => oderDate = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public double Total { get => total; set => total = value; }

        public Order()
        {
        }

        public Order(int orderId, DateTime oderDate, int customerId, int employeeId, double total)
        {
            this.orderId = orderId;
            this.oderDate = oderDate;
            this.customerId = customerId;
            this.employeeId = employeeId;
            this.total = total;
        }

        public void ConvertToObject(DataRow dr)
        {
            OrderId = dr.Field<int>(0);
            OderDate = dr.Field<DateTime>(1);
            CustomerId = dr.Field<int>(2);
            EmployeeId = dr.Field<int>(3);
            Total = dr.Field<double>(4);
        }
    }
}
