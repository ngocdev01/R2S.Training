using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using R2S.Training.Entities;

namespace R2S.Training.DAO
{
    public class ProductDAO
    {
        DataProvider dp;

        public ProductDAO()
        {
            dp = new DataProvider();
        }


        public List<Product> GetAllProduct(string field = null, string keyword = null, string orderby = null)
        {
            string sort = orderby != null ? (" order by [" + orderby + "]") : "";
            string find = field != null ? (" where [" + field + "] = " + keyword) : "";
            return dp.ExecuteQueryToList("select * from Product", typeof(Product), CommandType.Text, null)?.Cast<Product>().ToList();
        }
    }
}
