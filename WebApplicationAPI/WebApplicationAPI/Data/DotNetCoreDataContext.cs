using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Data
{
    public class DotNetCoreDataContext : DbContext
    {

        public DotNetCoreDataContext(DbContextOptions<DotNetCoreDataContext> options)
           : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

    }
}
