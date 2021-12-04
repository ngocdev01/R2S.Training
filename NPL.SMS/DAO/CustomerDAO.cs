
using System.Collections.Generic;
using System.Linq;
using System.Data;
using R2S.Training.Entities;
using System.Data.SqlClient;

namespace R2S.Training.DAO
{
    public class CustomerDAO : ICustomerDAO
    {
        DataProvider dp;

        public CustomerDAO()
        {
           dp = new DataProvider();
        }


        public List<Customer> GetAllCustomer(string field =null,string keyword = null,string orderby = null)
        {
            string sort = orderby != null ? (" order by [" + orderby + "]") : "";
            string find = field != null ? (" where [" + field + "] = " + keyword) : "";
            return dp.ExecuteQueryToList("select * from Customer" + find + sort, typeof(Customer), CommandType.Text, null)?.Cast<Customer>().ToList();
        }

        public bool AddCustomer(Customer customer, ref string error)
        {
            return dp.MyExecuteNonQuery("spAddCustomer",CommandType.StoredProcedure,ref error, 
                new SqlParameter("@customer_name",customer.CustomerName));
        }

        public bool DeleteCustomer(Customer customer, ref string error)
        {
            return dp.MyExecuteNonQuery("spDeleteCustomer",CommandType.StoredProcedure,ref error, 
                new SqlParameter("@customer_id",customer.CustomerId));
        }

        public bool UpdateCustomer(Customer customer, ref string error)
        {
            return dp.MyExecuteNonQuery("spUpdateCustomer",CommandType.StoredProcedure,ref error, 
                new SqlParameter("@customer_id",customer.CustomerId),
                new SqlParameter("@customer_name",customer.CustomerName) );
        }
    }
}
