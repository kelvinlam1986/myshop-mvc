using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shop.Migrations
{
    public partial class AddRequiredFieldProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Serial",
                table: "Products",
                type: "varchar(50)",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Serial",
                table: "Products",
                type: "varchar(50)",
                nullable: true);
        }
    }
}
