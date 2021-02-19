using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ado.netInNtier.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ado.netInNtier.Controllers
{
    public class ConsumerController : Controller
    {
        //normal listing
        public async Task<IActionResult> Index()
        {
            IList<Banks> banks = new List<Banks>();
            var response = await GetDetails();
          banks = JsonConvert.DeserializeObject<List<Banks>>(response);
            return View(banks);
        }
        public async Task<string> GetDetails()
        {
            using (var data = new HttpClient())
            {
                var path = "https://localhost:44360/api/Banks";
                using (var response = await data.GetAsync(path))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    return apiresponse;
                }

            }
        }
        //usingjquery
        public IActionResult IndexJQuery()
        {
            return View();
        }
    }
}
