﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineCommercialAutomation;

#nullable disable

namespace OnlineCommercialAutomation.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240102092159_ChangesDepartment")]
    partial class ChangesDepartment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineCommercialAutomation.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("Authority")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("Char");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("Varchar");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("Varchar");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CustomerCity")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("Varchar");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("Varchar");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeImage")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("Varchar");

                    b.Property<string>("EmployeeLastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.Expense", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Varchar");

                    b.HasKey("ExpenseId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.Invoice", b =>
                {
                    b.Property<int>("InvoicetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoicetId"));

                    b.Property<string>("Deliverer")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceSequenceNumber")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("Varchar");

                    b.Property<string>("InvoiceSerialNumber")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("Char");

                    b.Property<string>("Receiver")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar");

                    b.Property<string>("TaxAdministration")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("Varchar");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("InvoicetId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.InvoiceItem", b =>
                {
                    b.Property<int>("InvoiceItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceItemId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Varchar");

                    b.Property<int>("InvoicetId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceItemId");

                    b.HasIndex("InvoicetId");

                    b.ToTable("InvoiceItems");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("Condition")
                        .HasColumnType("bit");

                    b.Property<string>("ProductImage")
                        .HasMaxLength(250)
                        .HasColumnType("Varchar");

                    b.Property<string>("ProductName")
                        .HasMaxLength(30)
                        .HasColumnType("Varchar");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short>("Stock")
                        .HasColumnType("smallint");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.SalesMove", b =>
                {
                    b.Property<int>("SalesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalesId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SalesId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProductId");

                    b.ToTable("SalesMoves");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.Employee", b =>
                {
                    b.HasOne("OnlineCommercialAutomation.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.InvoiceItem", b =>
                {
                    b.HasOne("OnlineCommercialAutomation.Invoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoicetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.Product", b =>
                {
                    b.HasOne("OnlineCommercialAutomation.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.SalesMove", b =>
                {
                    b.HasOne("OnlineCommercialAutomation.Customer", "Customer")
                        .WithMany("SalesMoves")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineCommercialAutomation.Employee", "Employee")
                        .WithMany("SalesMoves")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineCommercialAutomation.Product", "Product")
                        .WithMany("SalesMoves")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.Customer", b =>
                {
                    b.Navigation("SalesMoves");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.Employee", b =>
                {
                    b.Navigation("SalesMoves");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.Invoice", b =>
                {
                    b.Navigation("InvoiceItems");
                });

            modelBuilder.Entity("OnlineCommercialAutomation.Product", b =>
                {
                    b.Navigation("SalesMoves");
                });
#pragma warning restore 612, 618
        }
    }
}
