using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shop.Migrations
{
    public partial class AddTermTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Down = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Due = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Interest = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PayableFor = table.Column<string>(type: "varchar(10)", nullable: false),
                    PaymentStart = table.Column<DateTime>(nullable: false),
                    SalesId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(type: "varchar(10)", nullable: true),
                    TermName = table.Column<string>(type: "varchar(11)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terms_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Terms_SalesId",
                table: "Terms",
                column: "SalesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Terms");
        }
    }
}
