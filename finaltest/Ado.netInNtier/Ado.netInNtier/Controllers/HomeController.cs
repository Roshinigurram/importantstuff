using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ado.netInNtier.Models;
using Microsoft.Extensions.Configuration;
using Ado.netInNtier.Data;
using BAL;
using System.Data;

namespace Ado.netInNtier.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _Context;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, ApplicationDbContext Context)
        {
            _logger = logger;
            _configuration = configuration;
            _Context = Context;
        }

        public IActionResult Index()
        {
            BankBAL bankBAL = new BankBAL();

            var data = bankBAL.ReadDetails();

            IList<Banks> banklist= new List<Banks>();
            foreach (DataRow row in data.Tables[0].Rows)
            {
               Banks banks = new Banks()
                {
                    BankId = int.Parse(row["BankId"].ToString()),
                   BankName = row["BankName"].ToString(),
                   BankAdress = row["BankAdress"].ToString(),

               };
                banklist.Add(banks);
            }
            return View(banklist);
        }

    


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
