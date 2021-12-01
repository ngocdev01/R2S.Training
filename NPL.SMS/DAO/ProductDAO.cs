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


        public List<Product> GetAllProduct()
        {
            return dp.ExecuteQueryDataSet("select * from Product order by [Product_Name]", typeof(Product), CommandType.Text, null)?.Cast<Product>().ToList();
        }
    }
}
