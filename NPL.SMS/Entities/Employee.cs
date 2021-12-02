using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Entities
{
    public class Employee : IConvert
    {
        int employeeId;
        string employeeName;
        double salary;
        int spvrId;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public double Salary { get => salary; set => salary = value; }
        public int SpvrId { get => spvrId; set => spvrId = value; }

        public Employee()
        {
        }

        public Employee(int employeeId, string employeeName, double salary, int spvrId)
        {
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.salary = salary;
            this.spvrId = spvrId;
        }

        public void ConvertToObject(DataRow dr)
        {
            EmployeeId = dr.Field<int>(0);
            EmployeeName = dr.Field<string>(1);
            Salary = dr.Field<double>(2);
            SpvrId = dr.Field<int>(3);
        }
        public override string ToString()
        {
            return "Employee ID: " + EmployeeId + ";         Employee Name: " + EmployeeName + 
                ";         Salary: " + Salary + ";         Supervisior ID:" + SpvrId;
        }
    }
}
