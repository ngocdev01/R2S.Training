using System.Collections.Generic;
using System.Linq;
using System.Data;
using R2S.Training.Entities;
using System.Data.SqlClient;

namespace R2S.Training.DAO
{
    class LineItemDAO
    {
        DataProvider dp;

        public LineItemDAO()
        {
           dp = new DataProvider();
        }

        public double ComputeOrderTotal(LineItem lineitem)
        {
            return double.Parse(dp.ExecuteQueryDataSet("spComputeOrderTotal", CommandType.StoredProcedure, 
                new SqlParameter("@order_id",lineitem.OrderId)).Tables[0].Rows[0][0].ToString());
        }

        public bool InsertLineItem(LineItem lineitem, ref string error)
        {
            return dp.MyExecuteNonQuery("spAddLineItem",CommandType.StoredProcedure,ref error, 
                new SqlParameter("@order_id",lineitem.OrderId),
                new SqlParameter("@product_id",lineitem.ProductId),
                new SqlParameter("@quantity",lineitem.Quantity),
                new SqlParameter("@price",lineitem.Price));
        }
    }
}
