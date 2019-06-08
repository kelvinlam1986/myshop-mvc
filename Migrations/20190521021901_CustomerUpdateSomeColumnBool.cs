using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shop.Migrations
{
    public partial class CustomerUpdateSomeColumnBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ValidId",
                table: "Customers",
                nullable: false);

            migrationBuilder.AlterColumn<bool>(
                name: "PaySlip",
                table: "Customers",
                nullable: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Income",
                table: "Customers",
                nullable: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Cert",
                table: "Customers",
                nullable: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Cedula",
                table: "Customers",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ValidId",
                table: "Customers",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "PaySlip",
                table: "Customers",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Income",
                table: "Customers",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Cert",
                table: "Customers",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Cedula",
                table: "Customers",
                nullable: false);
        }
    }
}
