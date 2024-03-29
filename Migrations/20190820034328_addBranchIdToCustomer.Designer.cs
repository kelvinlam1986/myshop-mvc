﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using shop.Data;

namespace shop.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20190820034328_addBranchIdToCustomer")]
    partial class addBranchIdToCustomer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(255);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(255);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(255);

                    b.Property<string>("RoleId")
                        .HasMaxLength(255);

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(255);

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("shop.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(255);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(255);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("shop.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Skin")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("shop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("shop.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("BranchId");

                    b.Property<bool>("Cedula");

                    b.Property<bool>("Cert");

                    b.Property<DateTime>("CiDate");

                    b.Property<string>("CiName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CiRemarks")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("CoMaker")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CoMakerDetails")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreditStatus")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("EmployerAddress")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmployerName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmployerNo")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("EmployerYear")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HouseStatus")
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("Income");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("PaySlip");

                    b.Property<string>("Picture")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Rent")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Salary")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Spouse")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SpouseDetails")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SpouseEmp")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SpouseIncome")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("SpouseNo")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("ValidId");

                    b.Property<string>("Years")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("shop.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CustomerId");

                    b.Property<decimal>("Due")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Interest")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("OrNo");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<DateTime>("PaymentFor");

                    b.Property<decimal>("Rebate")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Remaining")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("SalesId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SalesId");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("shop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(300)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Quantity");

                    b.Property<int>("Reorder");

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("SupplierId");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("shop.Models.Sales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AmountDue")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("CashChange")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("CashTendered")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("DateAdded");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("ModeOfPayment")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("UserId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("shop.Models.SalesDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<int>("SalesId");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SalesId");

                    b.ToTable("SalesDetails");
                });

            modelBuilder.Entity("shop.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Contact")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("shop.Models.TempTrans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("TempTrans");
                });

            modelBuilder.Entity("shop.Models.Term", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<decimal>("Down")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Due")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("DueDate");

                    b.Property<decimal>("Interest")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("PayableFor")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("PaymentStart");

                    b.Property<int>("SalesId");

                    b.Property<string>("Status")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("TermName")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("SalesId");

                    b.ToTable("Terms");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("shop.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("shop.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("shop.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("shop.Models.Customer", b =>
                {
                    b.HasOne("shop.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("shop.Models.Payment", b =>
                {
                    b.HasOne("shop.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("shop.Models.Sales", "Sales")
                        .WithMany()
                        .HasForeignKey("SalesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("shop.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("shop.Models.Product", b =>
                {
                    b.HasOne("shop.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("shop.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("shop.Models.Sales", b =>
                {
                    b.HasOne("shop.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("shop.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("shop.Models.SalesDetail", b =>
                {
                    b.HasOne("shop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("shop.Models.Sales", "Sales")
                        .WithMany("SalesDetails")
                        .HasForeignKey("SalesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("shop.Models.Term", b =>
                {
                    b.HasOne("shop.Models.Sales", "Sales")
                        .WithMany()
                        .HasForeignKey("SalesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
