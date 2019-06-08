using System;
using System.Linq;
using shop.Models;

namespace shop.Data
{
    public class DBInitializer
    {
        public static void Initialize(ShopContext context)
        {
            if (!context.Branches.Any())
            {
                context.Branches.Add(new Branch
                {
                    Name = "My Shop",
                    Address = "240/2 Lê Thánh Tôn P.Bến Thành Q1 TP.HCM",
                    Contact = "090 2305 226",
                    Skin = "skin-black",
                    CreatedBy = "admin",
                    CreatedDate = new DateTime(2019, 5, 16, 12, 0, 0),
                    UpdatedBy = "admin",
                    UpdatedDate = new DateTime(2019, 6, 16, 12, 0, 0)
                });
                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category
                {
                    Name = "Dầu gội",
                    CreatedBy = "admin",
                    CreatedDate = new DateTime(2019, 5, 16, 12, 0, 0),
                    UpdatedBy = "admin",
                    UpdatedDate = new DateTime(2019, 6, 16, 12, 0, 0)
                });

                context.Categories.Add(new Category
                {
                    Name = "Xà bông",
                    CreatedBy = "admin",
                    CreatedDate = new DateTime(2019, 5, 16, 12, 0, 0),
                    UpdatedBy = "admin",
                    UpdatedDate = new DateTime(2019, 6, 16, 12, 0, 0)
                });

                context.SaveChanges();
            }

            if (!context.Customers.Any())
            {
                context.Customers.Add(new Customer
                {
                    FirstName = "Honeylee",
                    LastName = "Minh",
                    Address = "Brgy. Busay, bago CIty",
                    Contact = "09051914070",
                    Balance = 303.20M,
                    Picture = "default.gif",
                    BirthDate = new DateTime(1989, 10, 14),
                    NickName = "lee",
                    HouseStatus = "owned",
                    Years = "27",
                    Rent = "NA",
                    EmployerNo = "",
                    EmployerName = "",
                    EmployerAddress = "",
                    EmployerYear = "",
                    Occupation = "",
                    Salary = "0.00",
                    Spouse = "",
                    SpouseNo = "",
                    SpouseEmp = "",
                    SpouseDetails = "",
                    SpouseIncome = "0",
                    CoMaker = "",
                    CoMakerDetails = "",
                    CreditStatus = "Approved",
                    CiDate = new DateTime(2019, 10, 10),
                    CiName = "Nga Nguyen",
                    CiRemarks = "Minh that la dep trai",
                    Cedula = true,
                    Cert = true,
                    ValidId = true,
                    PaySlip = true,
                    Income = true,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = "admin"
                });

                context.Customers.Add(new Customer
                {
                    FirstName = "Kenneth",
                    LastName = "Aboy",
                    Address = "Silay City",
                    Contact = "09098",
                    Balance = 0,
                    Picture = "default.gif",
                    BirthDate = new DateTime(1986, 10, 6),
                    NickName = "",
                    HouseStatus = "",
                    Years = "",
                    Rent = "NA",
                    EmployerNo = "",
                    EmployerName = "",
                    EmployerAddress = "",
                    EmployerYear = "",
                    Occupation = "",
                    Salary = "0.00",
                    Spouse = "",
                    SpouseNo = "",
                    SpouseEmp = "",
                    SpouseDetails = "",
                    SpouseIncome = "0",
                    CoMaker = "",
                    CoMakerDetails = "",
                    CreditStatus = "",
                    CiDate = new DateTime(1999, 1, 1),
                    CiName = "",
                    CiRemarks = "",
                    Cedula = false,
                    Cert = false,
                    ValidId = false,
                    PaySlip = false,
                    Income = false,
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now,
                    UpdatedBy = "admin",
                    UpdatedDate = DateTime.Now
                });

                context.SaveChanges();
            }

            if (!context.Suppliers.Any())
            {
                context.Suppliers.Add(new Supplier
                {
                    Name = "Công ty Teka",
                    Address = "123 Trần Hưng Đạo P. Bến Nghé Q1 TP.HCM",
                    Contact = "090 232 5228",
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now,
                    UpdatedBy = "admin",
                    UpdatedDate = DateTime.Now
                });
                context.Suppliers.Add(new Supplier
                {
                    Name = "Công ty Kelvin",
                    Address = "234 Nguyễn Trải P. Bến Thành Q1 TP.HCM",
                    Contact = "090 233 5228",
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now,
                    UpdatedBy = "admin",
                    UpdatedDate = DateTime.Now
                });
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                var firstCategory = context.Categories.FirstOrDefault();
                var firstSupplier = context.Suppliers.FirstOrDefault();
                context.Products.Add(new Product
                {
                    Name = "LG 43 UHD TV UH6100",
                    Description = "",
                    Price = 45000,
                    Picture = "default.gif",
                    CategoryId = firstCategory.Id,
                    Quantity = 10,
                    Reorder = 0,
                    SupplierId = firstSupplier.Id,
                    Serial = "19898981",
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now,
                    UpdatedBy = "admin",
                    UpdatedDate = DateTime.Now
                });
                context.Products.Add(new Product
                {
                    Name = "Rice Cooker",
                    Description = "",
                    Price = 30000,
                    Picture = "default.gif",
                    CategoryId = firstCategory.Id,
                    Quantity = 20,
                    Reorder = 10,
                    SupplierId = firstSupplier.Id,
                    Serial = "19898982",
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now,
                    UpdatedBy = "admin",
                    UpdatedDate = DateTime.Now
                });

                context.SaveChanges();
            }


        }
    }
}