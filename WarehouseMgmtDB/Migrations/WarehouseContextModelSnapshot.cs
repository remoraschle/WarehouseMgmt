﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarehouseMgmtDB;

namespace WarehouseMgmtDB.Migrations
{
    [DbContext(typeof(WarehouseContext))]
    partial class WarehouseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WarehouseMgmtDB.Model.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleGroupId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("WarehouseMgmtDB.Model.ArticleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticleGroupParentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleGroupParentId");

                    b.ToTable("ArticleGroups");
                });

            modelBuilder.Entity("WarehouseMgmtDB.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ValidFromUTC")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSUTCDATETIME()");

                    b.Property<DateTime?>("ValidToUTC")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CONVERT(DATETIME2, '9999-12-31 23:59:59.9999999')");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WarehouseMgmtDB.Model.OrderPositions", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ArticleId");

                    b.HasIndex("ArticleId");

                    b.ToTable("OrderPositions");
                });

            modelBuilder.Entity("WarehouseMgmtDB.Model.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WarehouseMgmtDB.Model.Article", b =>
                {
                    b.HasOne("WarehouseMgmtDB.Model.ArticleGroup", "ArticleGroup")
                        .WithMany()
                        .HasForeignKey("ArticleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArticleGroup");
                });

            modelBuilder.Entity("WarehouseMgmtDB.Model.ArticleGroup", b =>
                {
                    b.HasOne("WarehouseMgmtDB.Model.ArticleGroup", "ParentArticleGroup")
                        .WithMany("subGroups")
                        .HasForeignKey("ArticleGroupParentId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.Navigation("ParentArticleGroup");
                });

            modelBuilder.Entity("WarehouseMgmtDB.Model.OrderPositions", b =>
                {
                    b.HasOne("WarehouseMgmtDB.Model.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseMgmtDB.Model.Orders", "Orders")
                        .WithMany("OrderPositions")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WarehouseMgmtDB.Model.Orders", b =>
                {
                    b.HasOne("WarehouseMgmtDB.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("WarehouseMgmtDB.Model.ArticleGroup", b =>
                {
                    b.Navigation("subGroups");
                });

            modelBuilder.Entity("WarehouseMgmtDB.Model.Orders", b =>
                {
                    b.Navigation("OrderPositions");
                });
#pragma warning restore 612, 618
        }
    }
}
