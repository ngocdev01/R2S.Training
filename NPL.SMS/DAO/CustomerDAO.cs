
using System.Collections.Generic;
using System.Linq;
using System.Data;
using R2S.Training.Entities;

namespace R2S.Training.DAO
{
    public class CustomerDAO
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
            return dp.ExecuteQueryDataSet("select * from Customer" + find + sort, typeof(Customer), CommandType.Text, null)?.Cast<Customer>().ToList();
        }
    }
}
