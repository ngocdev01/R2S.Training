using R2S.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.DAO
{
    interface ILineItemDAO
    {
        List<LineItem> GetAllItemsByOrderId(string field = null, string keyword = null, string orderby = null); //Câu 3

        double ComputeOrderTotal(LineItem lineitem); //Câu 4

        bool AddLineItem(LineItem lineitem, ref string error); //Câu 9
    }
}
