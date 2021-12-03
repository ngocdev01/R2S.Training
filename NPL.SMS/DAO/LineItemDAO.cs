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
    }
}
