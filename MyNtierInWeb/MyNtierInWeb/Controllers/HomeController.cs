using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyNtierInWeb.Data;
using MyNtierInWeb.Models;

namespace MyNtierInWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _Context;

        public HomeController(ILogger<HomeController> logger,IConfiguration configuration,ApplicationDbContext Context)
        {
            _logger = logger;
            _configuration = configuration;
            _Context=Context;
        }

        public IActionResult Index()
        {
            EmployeeBAL bal = new EmployeeBAL();
            var data=bal.ReadEmployees();

            IList<Employee> emplist = new List<Employee>();
            foreach (DataRow row in data.Tables[0].Rows)
            {
                Employee employee = new Employee()
                {
                      Id=int.Parse(row["Id"].ToString()),
                      EmpName=row["EmpName"].ToString(),
                      Salary=decimal.Parse(row["Salary"].ToString()),
                    DeptNo = int.Parse(row["DeptNo"].ToString()),

                };
               emplist.Add(employee);
            }
            return View(emplist);            
        }
        public IActionResult Search()
        {
            var data = _Context.Employee.ToList();
            return View(data);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Search(IFormCollection form)
        //{
        //    var fieldName = form["FieldName"].ToString();
        //    var keyword = form["Keyword"].ToString();

        //    IList<Employee> employees = new List<Employee>();
        //    switch (fieldName)
        //    {
        //        case "ID":
        //            var id = int.Parse(keyword);
        //            employees = _Context.Employee.Where(d => d.ID.Equals(id)).ToList();
        //            break;
        //        case "Name":
        //            employees = _Context.Employee.Where(d => d.FullName.StartsWith(keyword)).OrderBy(d => d.FullName).ToList();
        //            break;
        //        case "Age":
        //            var age = int.Parse(keyword);
        //            employees = _Context.Employee.Where(d => d.Age.Equals(age)).ToList();
        //            break;
        //        case "DOJ":
        //            var doj = DateTime.Parse(keyword);
        //            employees = _Context.Employee.Where(d => d.DOJ.Equals(doj)).ToList();
        //            break;
        //    }

        //    return View(employees);
        //}




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
