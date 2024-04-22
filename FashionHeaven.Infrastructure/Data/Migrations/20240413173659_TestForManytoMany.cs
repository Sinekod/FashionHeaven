using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionHeaven.Data.Migrations
{
    public partial class TestForManytoMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductGenderId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGenderId",
                table: "Products",
                column: "ProductGenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGenders_ProductGenderId",
                table: "Products",
                column: "ProductGenderId",
                principalTable: "ProductGenders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGenders_ProductGenderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductGenderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductGenderId",
                table: "Products");
        }
    }
}
