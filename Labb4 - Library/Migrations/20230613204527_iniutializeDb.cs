using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb4___Library.Migrations
{
    /// <inheritdoc />
    public partial class iniutializeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookItems",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookItems", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomersLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "BookLoans",
                columns: table => new
                {
                    BookLoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKCustomerId = table.Column<int>(type: "int", nullable: true),
                    FkBookId = table.Column<int>(type: "int", nullable: true),
                    Loaned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReturned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsLoaned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLoans", x => x.BookLoanId);
                    table.ForeignKey(
                        name: "FK_BookLoans_BookItems_FkBookId",
                        column: x => x.FkBookId,
                        principalTable: "BookItems",
                        principalColumn: "BookId");
                    table.ForeignKey(
                        name: "FK_BookLoans_Customers_FKCustomerId",
                        column: x => x.FKCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.InsertData(
                table: "BookItems",
                columns: new[] { "BookId", "Author", "Description", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, "George RR Martin", "Fantasybook about ice and fire", 4, "Song of ice and fire" },
                    { 2, "Tolkien", "Fantasybook about Gandalf mostly", 3, "Lord of the rings" },
                    { 3, "Tolkien", "Fantasybook about Gandalf mostly", 3, "Story of the two towers" },
                    { 4, "Tolkien", "Fantasybook about Gandalf mostly", 3, "Return of the king" },
                    { 5, "John Grogan", "My life with the craziest dog ever as a companion", 2, "Marley and Me" },
                    { 6, "Sebastian Marroquin", "Pablo Escobars life and death", 1, "Pablo Escobar Memoirs" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerFirstName", "CustomersLastName", "Email", "ImgURL", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Oskar", "Åhling", "Oskar@Mail.com", "", "070-2138149" },
                    { 2, "Ina", "Nilsson", "Ina@Mail.com", "", "070-2138150" },
                    { 3, "Bamse", "Bomsisson", "Bomse@Mail.com", "", "070-0909090" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_FkBookId",
                table: "BookLoans",
                column: "FkBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_FKCustomerId",
                table: "BookLoans",
                column: "FKCustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLoans");

            migrationBuilder.DropTable(
                name: "BookItems");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
