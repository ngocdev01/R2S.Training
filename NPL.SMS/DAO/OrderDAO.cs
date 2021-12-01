
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
        public List<Order> GetAllOrder(string field = null, string keyword = null, string orderby = null)
        {
            string sort = orderby != null ? (" order by [" + orderby + "]") : "";
            string find = field != null ? (" where [" + field + "] = " + keyword) : "";
            return dp.ExecuteQueryDataSet("select * from Orders" + find + sort, typeof(Order), CommandType.Text, null).Cast<Order>().ToList();
        }
    }
}
