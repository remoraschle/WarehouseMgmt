using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarehouseMgmtDB.Model;
using Microsoft.EntityFrameworkCore.Proxies;


namespace WarehouseMgmtDB
{
    public class WarehouseContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleGroup> ArticleGroups { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderPositions> OrderPositions { get; set; }
        public DbSet<Orders> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=WarehouseDB;Trusted_Connection=True");
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

    }
}
