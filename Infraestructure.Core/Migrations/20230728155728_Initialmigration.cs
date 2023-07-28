using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    IdInvoice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientAddress = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ClientPhone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    ClientDocument = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Iva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalInvoice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.IdInvoice);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    IdInvoice = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Invoice_IdInvoice",
                        column: x => x.IdInvoice,
                        principalTable: "Invoice",
                        principalColumn: "IdInvoice",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_IdInvoice",
                table: "InvoiceDetail",
                column: "IdInvoice");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_IdProduct",
                table: "InvoiceDetail",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Code",
                table: "Product",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
