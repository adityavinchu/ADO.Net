using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace EmplyeePayrollService
{
    public class EmployeeOperation
    {
        private SqlConnection con;
        public void Connection()
        {
            string constr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Payroll_service;Integrated Security=True;MultipleActiveResultSets=True";
            con = new SqlConnection(constr);
        }
        public void GetAllEmployees()
        {
            Connection();
            List<Employee> EmpList = new List<Employee>();
            SqlCommand com = new SqlCommand("spGetEmployee", con);
            com.CommandType = CommandType.StoredProcedure;
            // SqlCommand com = new SqlCommand("select * from Employe_Payroll", con);
            //com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(
                    new Employee
                    {

                        id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        StartDate = Convert.ToDateTime(dr["StartDate"]),
                        Gender = Convert.ToString(dr["Gender"]),
                        Phonenumber = Convert.ToString(dr["Phonenumber"]),
                        Address = Convert.ToString(dr["Address"]),
                        BasicPay = Convert.ToInt32(dr["BasicPay"]),

                        Deduction = Convert.ToInt32(dr["Deduction"]),
                        TaxablePay = Convert.ToInt32(dr["TaxablePay"]),
                        Incometax = Convert.ToInt32(dr["Incometax"]),
                        Netpay = Convert.ToInt32(dr["Netpay"]),
                    }
                    );
            }
            Display(EmpList);
        }
        public bool Addemployee(Employee obj)
        {
            Connection();
            SqlCommand com = new SqlCommand("InsertEmployeeData", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@StartDate", obj.StartDate);
            com.Parameters.AddWithValue("@Gender", obj.Gender);
            com.Parameters.AddWithValue("@Phonenumber", obj.Phonenumber);
            com.Parameters.AddWithValue("@address", obj.Address);
            com.Parameters.AddWithValue("@BasicPay", obj.BasicPay);
            com.Parameters.AddWithValue("@deduction", obj.Deduction);
            com.Parameters.AddWithValue("@TaxablePay", obj.TaxablePay);
            com.Parameters.AddWithValue("@Incometax", obj.Incometax);
            com.Parameters.AddWithValue("@Netpay", obj.Netpay);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double UpdateEmployee(Employee obj)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("EmployeeUpdateSalery", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@name", obj.Name);
                com.Parameters.AddWithValue("@salery", obj.BasicPay);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {

                    return obj.BasicPay;
                }
                else
                {
                    return 0.0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void Display(List<Employee> employees)
        {
            foreach (var data in employees)
            {
                Console.WriteLine(data.Name + " " + data.StartDate);
            }
        }
        public bool DeleteEmployee(string name)
        {
            Connection();
            SqlCommand com = new SqlCommand("DeleteEmpByName", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@name", name);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
