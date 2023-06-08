﻿// <auto-generated />
using System;
using Infraestructure.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230607185408_addInvoiceTable")]
    partial class addInvoiceTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Infraestructure.Entity.Models.InvoiceDetailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("IdInvoice")
                        .HasColumnType("int");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalSale")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdInvoice");

                    b.HasIndex("IdProduct");

                    b.ToTable("InvoiceDetail");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.InvoiceEntity", b =>
                {
                    b.Property<int>("IdBill")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBill"), 1L, 1);

                    b.Property<string>("ClientAddress")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ClientLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ClientPhone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Iva")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalInvoice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdBill");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.InvoiceDetailEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.InvoiceEntity", "InvoiceEntity")
                        .WithMany("InvoiceDetailEntities")
                        .HasForeignKey("IdInvoice")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.ProductEntity", "ProductEntity")
                        .WithMany("InvoiceDetailEntities")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvoiceEntity");

                    b.Navigation("ProductEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.InvoiceEntity", b =>
                {
                    b.Navigation("InvoiceDetailEntities");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ProductEntity", b =>
                {
                    b.Navigation("InvoiceDetailEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
