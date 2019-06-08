using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shop.Migrations
{
    public partial class MisTypeColumnNameCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmpployerYear",
                table: "Customers",
                newName: "EmployerYear");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployerYear",
                table: "Customers",
                newName: "EmpployerYear");
        }
    }
}
