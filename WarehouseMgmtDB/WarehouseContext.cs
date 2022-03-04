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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ArticleGroup>()
                .HasMany(p => p.subGroups)
                .WithOne(p => p.ParentArticleGroup)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasForeignKey(p => p.ArticleGroupParentId);


            //modelBuilder.Entity<OrderPositions>()
            //    .HasNoKey()
            //    .HasOne(p=>p.Orders)
            //    .WithOne(p => p.OrderPositions)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .HasForeignKey<Orders>(p=>p.Id);


            modelBuilder.Entity<OrderPositions>().HasKey(x => new { x.OrderId, x.ArticleId });

            modelBuilder.Entity<Customer>().HasKey(x => x.Id);

            modelBuilder.Entity<Customer>().Property(x => x.ValidFromUTC)
                                         .IsRequired()
                                         .ValueGeneratedOnAddOrUpdate()
                                         .HasDefaultValueSql("SYSUTCDATETIME()");

            modelBuilder.Entity<Customer>().Property(x => x.ValidToUTC)
                                         .IsRequired()
                                         .ValueGeneratedOnAddOrUpdate()
                                         .HasDefaultValueSql("CONVERT(DATETIME2, '9999-12-31 23:59:59.9999999')");



            base.OnModelCreating(modelBuilder);

        }

    }
}
