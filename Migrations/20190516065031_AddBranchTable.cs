using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shop.Migrations
{
    public partial class AddBranchTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Skin = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branch");
        }
    }
}
