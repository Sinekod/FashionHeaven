using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionHeaven.Data.Migrations
{
    public partial class GenderNamesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GenderName",
                table: "ProductGenders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ProductGenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "GenderName",
                value: "Men");

            migrationBuilder.UpdateData(
                table: "ProductGenders",
                keyColumn: "Id",
                keyValue: 2,
                column: "GenderName",
                value: "Women");

            migrationBuilder.UpdateData(
                table: "ProductGenders",
                keyColumn: "Id",
                keyValue: 3,
                column: "GenderName",
                value: "Kids");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GenderName",
                table: "ProductGenders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ProductGenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "GenderName",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductGenders",
                keyColumn: "Id",
                keyValue: 2,
                column: "GenderName",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductGenders",
                keyColumn: "Id",
                keyValue: 3,
                column: "GenderName",
                value: 2);
        }
    }
}
