using ApiApplicationnew.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiApplicationnew.Data
{
    public class ContextClass : DbContext
    {
        public ContextClass(DbContextOptions<ContextClass> options)
            : base(options)
        {

        }
        public DbSet<Banks> banks { get; set; }
    }
}
