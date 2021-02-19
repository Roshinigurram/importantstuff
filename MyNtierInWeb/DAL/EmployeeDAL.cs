using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class EmployeeDAL
    {
        static string ConnStr = "Data Source=192.168.50.95;Initial Catalog=rgurram;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";

        public DataTable GetEmployees()
        {
            DataTable table = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnStr))
            {
                using (SqlCommand sqlCommand=new SqlCommand("select * from employee",sqlConnection))
                {

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.Fill(table);
                    }
                }

            }
            return table;
        }


    }
}
