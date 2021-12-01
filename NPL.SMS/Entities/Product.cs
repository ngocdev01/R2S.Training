using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Entities
{
    public class Product : IConvert
    {
        int productID;
        string productName;
        double productPrice;

        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public double ProductPrice { get => productPrice; set => productPrice = value; }

        public Product()
        {
        }

        public Product(int productID, string productName, double productPrice)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.ProductPrice = productPrice;
        }

        public void ConvertToObject(DataRow dr)
        {
            ProductID = dr.Field<int>(0);
            ProductName = dr.Field<string>(1);
            ProductPrice = dr.Field<double>(2);
        }
        public override string ToString()
        {
            return " Product ID: " + ProductID + "; Product Name: " + productName + "; Product Price: " + ProductPrice;
        }
    }
}
