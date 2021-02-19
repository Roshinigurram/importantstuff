using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ListingAllproject4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;

namespace ListingAllproject4.Controllers
{
    public class ListOfAll : Controller
    {
        static string ConnectionString = "Data Source=192.168.50.95;Initial Catalog=rgurram;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";

        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cacheData;


        public ListOfAll(ApplicationDbContext context, IMemoryCache cacheData)
        {
            _context = context;
            _cacheData = cacheData;

        }

        public ActionResult Index()
        {
            DataTable table = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                 var sql = "select T.
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
    }

     
