
using System.Collections.Generic;
using System.Linq;
using System.Data;
using R2S.Training.Entities;


namespace R2S.Training.DAO
{
    public class OrderDAO
    {
        DataProvider dp;

        public OrderDAO()
        {
            dp = new DataProvider();

            
        }
        public List<Order> GetAllOrderByCustomerId(string field = null, string keyword = null, string orderby = null)
        {
            string sort = orderby != null ? (" order by [" + orderby + "]") : "";
            string find = field != null ? (" where [" + field + "] = " + keyword) : "";
            return dp.ExecuteQueryToList("select * from Orders" + find + sort, typeof(Order), CommandType.Text, null).Cast<Order>().ToList();
        }

        public bool InsertOrder(Order order, ref string error)
        {
            return dp.MyExecuteNonQuery("spAddOrder",CommandType.StoredProcedure,ref error, 
                new SqlParameter("@order_date",order.OderDate),
                new SqlParameter("@customer_id",order.CustomerId),
                new SqlParameter("@employee_id",order.EmployeeId) );
        }

        public bool UpdateOrderTotal(Order order, ref string error)
        {
            return dp.MyExecuteNonQuery("spUpdateOrderTotal",CommandType.StoredProcedure,ref error, 
                new SqlParameter("@order_id", order.OrderId) );
        } 
    }
}
