using R2S.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.DAO
{
    interface IProductDAO
    {
        List<Product> GetAllProduct(string field = null, string keyword = null, string orderby = null); //Thêm
    }
}
