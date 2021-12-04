using R2S.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.DAO
{
    interface IOrderDAO
    {
        List<Order> GetAllOrderByCustomerId(string field = null, string keyword = null, string orderby = null); //Câu 2

        bool AddOrder(Order order, ref string error); //Câu 8

        bool UpdateOrderTotal(int orderId, ref string error); //Câu 10
    }
}
