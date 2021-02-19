using EntityFramework.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Migration
{
    public class EntityContext : DbContext
    {
        public string connectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            connectionString = "Data Source=192.168.50.95;Initial Catalog=sprathipati;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Order> Orderss { get; set; }
        public DbSet<Product> Productss { get; set; }
    }
}
