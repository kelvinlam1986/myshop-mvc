using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shop.Migrations
{
    public partial class UpdateNullCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Years",
                table: "Customers",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SpouseNo",
                table: "Customers",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SpouseEmp",
                table: "Customers",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SpouseDetails",
                table: "Customers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Spouse",
                table: "Customers",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Salary",
                table: "Customers",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rent",
                table: "Customers",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Customers",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Occupation",
                table: "Customers",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NickName",
                table: "Customers",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HouseStatus",
                table: "Customers",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmpployeeYear",
                table: "Customers",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeNo",
                table: "Customers",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeName",
                table: "Customers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeAddress",
                table: "Customers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreditStatus",
                table: "Customers",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CoMakerDetails",
                table: "Customers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CoMaker",
                table: "Customers",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CiRemarks",
                table: "Customers",
                type: "nvarchar(1000)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CiName",
                table: "Customers",
                type: "nvarchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Years",
                table: "Customers",
                type: "varchar(20)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "SpouseNo",
                table: "Customers",
                type: "varchar(30)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "SpouseEmp",
                table: "Customers",
                type: "nvarchar(50)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "SpouseDetails",
                table: "Customers",
                type: "nvarchar(100)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Spouse",
                table: "Customers",
                type: "nvarchar(30)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Salary",
                table: "Customers",
                type: "nvarchar(30)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Rent",
                table: "Customers",
                type: "nvarchar(10)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Customers",
                type: "varchar(300)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Occupation",
                table: "Customers",
                type: "nvarchar(30)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "NickName",
                table: "Customers",
                type: "nvarchar(30)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "HouseStatus",
                table: "Customers",
                type: "varchar(30)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "EmpployeeYear",
                table: "Customers",
                type: "varchar(10)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeNo",
                table: "Customers",
                type: "nvarchar(30)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeName",
                table: "Customers",
                type: "nvarchar(100)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeAddress",
                table: "Customers",
                type: "nvarchar(100)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "CreditStatus",
                table: "Customers",
                type: "varchar(10)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "CoMakerDetails",
                table: "Customers",
                type: "nvarchar(100)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "CoMaker",
                table: "Customers",
                type: "nvarchar(30)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "CiRemarks",
                table: "Customers",
                type: "nvarchar(1000)",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "CiName",
                table: "Customers",
                type: "nvarchar(50)",
                nullable: false);
        }
    }
}
