using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplicationAPIConsumer.Models;

namespace WebApplicationAPIConsumer.Controllers
{
    public class PeopleConsumerController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IList<Person> people = new List<Person>();
            var apiResponse = await GetAPIResponseAsync();
            people = JsonConvert.DeserializeObject<List<Person>>(apiResponse);
            return View(people);
        }

        public async Task<string> GetAPIResponseAsync()
        {
            using (var client = new HttpClient())
            {
                var fullApiPath = "http://localhost:57573/api/People";
                using (var response = await client.GetAsync(fullApiPath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
            }
        }

        public IActionResult Create()
        {
            return View(new Person());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoId,FirstName,LastName,Age,Active")] Person person)
        {
            if (ModelState.IsValid)
            {
                var jsonString = JsonConvert.SerializeObject(person);
                var stringContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

                var apiResponse = await PostAPIResponseAsync(stringContent);
                var response = apiResponse;
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        private async Task<string> PostAPIResponseAsync(StringContent stringContent)
        {
            using (var client = new HttpClient())
            {
                var fullApiPath = "http://localhost:57573/api/People";
                using (var response = await client.PostAsync(fullApiPath, stringContent))
                {
                    var res = await response.Content.ReadAsStringAsync();
                    return res;
                }
            }
        }

        public async Task<IActionResult> IndexJquery()
        {
            return View();
        }

    }
}