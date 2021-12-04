using System;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using R2S.Training.Entities;

namespace R2S.Training.DAO
{
    public class DataProvider
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataAdapter adp;

		public DataProvider()
        {
			cnn = new SqlConnection(GetConnectionString());
			cmd = cnn.CreateCommand();
        }

		string GetConnectionString()
		{
			SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
			connectionStringBuilder.DataSource =  @"ADMINMI-QJ4NRGA\MISAMIMOSA2014";
			connectionStringBuilder.InitialCatalog = "OOP";
			connectionStringBuilder.IntegratedSecurity = true;
			return connectionStringBuilder.ConnectionString;

		}
		public List<IConvert> ExecuteQueryToList(
			string strSQL,Type type, CommandType ct,
			params SqlParameter[] param)
		{
			
			cmd.CommandText = strSQL;
			cmd.CommandType = ct;
			if (param != null)
			{
				cmd.Parameters.Clear();
				foreach (SqlParameter p in param)
					cmd.Parameters.Add(p);
			}
			adp = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			try
			{
			
				adp.Fill(ds);
				return GetListFromTable(ds.Tables[0],type);
				
			}
			catch (Exception)
			{
				return null;
			}
			
		}

		public DataSet ExecuteQueryDataSet(
			string strSQL, CommandType ct,
			params SqlParameter[] param)
		{
			cmd.CommandText = strSQL;
			cmd.CommandType = ct;
			if (param != null)
			{
				cmd.Parameters.Clear();
				foreach (SqlParameter p in param)
					cmd.Parameters.Add(p);
			}
			adp = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			try
			{		
				adp.Fill(ds);
			}catch(Exception)
            {
				return null;
            }			
			return ds;
		}


		public bool MyExecuteNonQuery(string strSQL,
			CommandType ct, ref string error,
			params SqlParameter[] param)
		{
			bool f = false;
			cnn.Open();
			cmd.Parameters.Clear();
			cmd.CommandText = strSQL;
			cmd.CommandType = ct;
			foreach (SqlParameter p in param)
				cmd.Parameters.Add(p);
			try
			{
				cmd.ExecuteNonQuery();
				f = true;

			}
			catch (SqlException ex)
			{
				error = ex.Message;
			}
			finally
			{
				cnn.Close();
			}
			return f;
		}

		List<IConvert> GetListFromTable(DataTable dt, Type type)
		{
			List<IConvert> li = new List<IConvert>();

			if (type.Equals(typeof(Customer)))
			{
				foreach (DataRow row in dt.Rows)
				{
					Customer cs = new Customer();
					cs.ConvertToObject(row);
					li.Add(cs);
				}
				return li;
			}
			if (type.Equals(typeof(Employee)))
			{
				foreach (DataRow row in dt.Rows)
				{
					Employee cs = new Employee();
					cs.ConvertToObject(row);
					li.Add(cs);
				}
				return li;
			}
			if (type.Equals(typeof(Order)))
			{
				foreach (DataRow row in dt.Rows)
				{
					Order cs = new Order();
					cs.ConvertToObject(row);
					li.Add(cs);
				}
				return li;
			}
			if (type.Equals(typeof(Product)))
			{
				foreach (DataRow row in dt.Rows)
				{
					Product cs = new Product();
					cs.ConvertToObject(row);
					li.Add(cs);
				}
				return li;
			}
			if (type.Equals(typeof(LineItem)))
			{
				foreach (DataRow row in dt.Rows)
				{
					LineItem cs = new LineItem();
					cs.ConvertToObject(row);
					li.Add(cs);
				}
				return li;
			}



			return null;
		}

	}
}


