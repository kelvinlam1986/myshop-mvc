using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shop.Migrations
{
    public partial class RenameColumnCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmpployeeYear",
                table: "Customers",
                newName: "EmpployerYear");

            migrationBuilder.RenameColumn(
                name: "EmployeeNo",
                table: "Customers",
                newName: "EmployerNo");

            migrationBuilder.RenameColumn(
                name: "EmployeeName",
                table: "Customers",
                newName: "EmployerName");

            migrationBuilder.RenameColumn(
                name: "EmployeeAddress",
                table: "Customers",
                newName: "EmployerAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmpployerYear",
                table: "Customers",
                newName: "EmpployeeYear");

            migrationBuilder.RenameColumn(
                name: "EmployerNo",
                table: "Customers",
                newName: "EmployeeNo");

            migrationBuilder.RenameColumn(
                name: "EmployerName",
                table: "Customers",
                newName: "EmployeeName");

            migrationBuilder.RenameColumn(
                name: "EmployerAddress",
                table: "Customers",
                newName: "EmployeeAddress");
        }
    }
}
