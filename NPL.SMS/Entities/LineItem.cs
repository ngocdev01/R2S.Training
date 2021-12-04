using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Entities
{
    public class LineItem : IConvert
    {
        int orderId;
        int productId;
        int quantity;
        double price;

        public int OrderId { get => orderId; set => orderId = value; }
        public int ProductId { get => productId; set => productId = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Price { get => price; set => price = value; }

        public LineItem()
        {

        }

        public LineItem(int orderId, int productId, int quantity, double price)
        {
            this.orderId = orderId;
            this.productId = productId;
            this.quantity = quantity;
            this.price = price;
        }

        public void ConvertToObject(DataRow dr)
        {
            OrderId = dr.Field<int>(0);
            ProductId = dr.Field<int>(2);
            Quantity = dr.Field<int>(2);
            Price = dr.Field<double>(3);
        }
        public override string ToString()
        {
            return "Order ID: " + OrderId + ";        " + "ProductId: " + ProductId + 
                ";         Quantity: " + Quantity + ";           Price: " + Price;

        }
    }
}
