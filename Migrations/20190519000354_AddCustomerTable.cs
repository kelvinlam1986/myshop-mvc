using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shop.Migrations
{
    public partial class AddCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Cedula = table.Column<int>(nullable: false),
                    Cert = table.Column<int>(nullable: false),
                    CiDate = table.Column<DateTime>(nullable: false),
                    CiName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CiRemarks = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    CoMaker = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CoMakerDetails = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Contact = table.Column<string>(type: "varchar(30)", nullable: false),
                    CreditStatus = table.Column<string>(type: "varchar(10)", nullable: false),
                    EmployeeAddress = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    EmployeeNo = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    EmpployeeYear = table.Column<string>(type: "varchar(10)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    HouseStatus = table.Column<string>(type: "varchar(30)", nullable: false),
                    Income = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PaySlip = table.Column<int>(nullable: false),
                    Picture = table.Column<string>(type: "varchar(300)", nullable: false),
                    Rent = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Salary = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Spouse = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    SpouseDetails = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SpouseEmp = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SpouseIncome = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SpouseNo = table.Column<string>(type: "varchar(30)", nullable: false),
                    ValidId = table.Column<int>(nullable: false),
                    Years = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
