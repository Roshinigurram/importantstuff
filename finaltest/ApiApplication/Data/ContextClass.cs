using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApplication.Data
{
   
        public class ContextClass : DbContext
        {
            public ContextClass(DbContextOptions<ContextClass> options)
                : base(options)
            {

            }
            public DbSet<>  { get; set; }
        }
    }
}
