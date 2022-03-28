using System;

namespace EmplyeePayrollService
{
    public class Employee
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public Double BasicPay { get; set; }
        public int Deduction { get; set; }
        public int TaxablePay { get; set; }
        public int Incometax { get; set; }
        public int Netpay { get; set; }

    }
}