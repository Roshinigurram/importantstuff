using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ado.netinmvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ado.netinmvc.Controllers
{
    public class EmployeeController1 : Controller
    {
        // GET: EmployeeController1
        static string ConnectionString = "Data Source=192.168.50.95;Initial Catalog=rgurram;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
        public ActionResult Index()
        {
            DataTable table = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                var sql = "select * from employee";
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.Fill(table);
                    }
                }
            }
            return View(table);
        }



        public ActionResult Create()
        {
            return View(new Employee());

        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var data = "insert into employee values(@EmpName,@Salary,@DeptNo)";
                using (SqlCommand sqlCommand = new SqlCommand(data, sqlConnection))
                {

                    sqlCommand.Parameters.AddWithValue("@EmpName", employee.EmpName);
                    sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
                    sqlCommand.Parameters.AddWithValue("@DeptNo", employee.DeptNo);
                    sqlCommand.ExecuteNonQuery();



                }

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EmployeeController1/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = new Employee();
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var sql3 = "select * from Employee where Id = @Id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql3, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@Id", id);
                adapter.Fill(table);
                //connection.Close();
            }
            if (table.Rows.Count == 1)
            {
                employee.Id = Convert.ToInt32(table.Rows[0][0].ToString());
                employee.EmpName = table.Rows[0][1].ToString();
                employee.Salary = Convert.ToDecimal(table.Rows[0][2].ToString());
                employee.DeptNo = Convert.ToInt32(table.Rows[0][3].ToString());
                return View(employee);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: EmployeeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var data = "Update employee set EmpName=@EmpName ,Salary=@Salary,DeptNo=@DeptNo where Id=@Id";
                SqlCommand sqlCommand = new SqlCommand(data, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@Id", employee.Id);
                sqlCommand.Parameters.AddWithValue("@EmpName", employee.EmpName);
                sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
                sqlCommand.Parameters.AddWithValue("@DeptNo", employee.DeptNo);
                sqlCommand.ExecuteNonQuery();
                //sqlConnection.Close();
            }

        

            return RedirectToAction(nameof(Index));
    }




        public ActionResult Details(int id)
        {
            Employee employee = new Employee();
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var sql3 = "select * from Employee where Id = @Id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql3, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@Id", id);
                adapter.Fill(table);
                //connection.Close();
            }
            if (table.Rows.Count == 1)
            {
                employee.Id = Convert.ToInt32(table.Rows[0][0].ToString());
                employee.EmpName = table.Rows[0][1].ToString();
                employee.Salary = Convert.ToDecimal(table.Rows[0][2].ToString());
                employee.DeptNo = Convert.ToInt32(table.Rows[0][3].ToString());
                return View(employee);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
        public ActionResult Delete(int id)
        {
            using(SqlConnection sqlConnection =new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var data = "delete from employee where Id=@Id";
                SqlCommand sqlCommand = new SqlCommand(data, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }
    }
}
