using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplyeePayrollService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeOperation emp = new EmployeeOperation();
            Employee employee = new Employee();
            employee.Name = "Amit";
            employee.BasicPay = 5000;
            double result = emp.UpdateEmployee(employee);
            Console.WriteLine(result);
        }
    }
}
