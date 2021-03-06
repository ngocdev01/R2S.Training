using System.Collections.Generic;
using System.Linq;
using System.Data;
using R2S.Training.Entities;
using System.Data.SqlClient;
using System;

namespace R2S.Training.DAO
{
    class LineItemDAO : ILineItemDAO
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

        public bool AddLineItem(LineItem lineitem, ref string error)
        {
            return dp.MyExecuteNonQuery("spAddLineItem",CommandType.StoredProcedure,ref error, 
                new SqlParameter("@order_id",lineitem.OrderId),
                new SqlParameter("@product_id",lineitem.ProductId),
                new SqlParameter("@quantity",lineitem.Quantity),
                new SqlParameter("@price",lineitem.Price));
        }

        public List<LineItem> GetAllItemsByOrderId(string field = null, string keyword = null, string orderby = null)
        {
            string sort = orderby != null ? (" order by [" + orderby + "]") : "";
            string find = field != null ? (" where [" + field + "] = " + keyword) : "";
            return dp.ExecuteQueryToList("select * from LineItem" + find + sort, typeof(LineItem), CommandType.Text, null).Cast<LineItem>().ToList();
            
        }

        public bool AddLineItem(LineItem item)
        {
            string e = "";
            return dp.MyExecuteNonQuery("spAddLineItem", CommandType.StoredProcedure, ref e,
                new SqlParameter("@order_id", item.OrderId),
                new SqlParameter("@product_id", item.ProductId),
                new SqlParameter("@quantity", item.Quantity),
                new SqlParameter("@price", item.Price));
        }
    }
}
