using R2S.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.DAO
{
    interface ICustomerDAO
    {
        List<Customer> GetAllCustomer(string field = null, string keyword = null, string orderby = null); //Câu 1

        bool AddCustomer(Customer customer, ref string error); //Câu 5

        bool DeleteCustomer(Customer customer, ref string error); ////Câu 6

        bool UpdateCustomer(Customer customer, ref string error); //Câu 7
    }
}
