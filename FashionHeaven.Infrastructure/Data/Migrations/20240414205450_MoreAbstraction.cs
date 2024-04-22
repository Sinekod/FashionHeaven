using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionHeaven.Data.Migrations
{
    public partial class MoreAbstraction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Sizes_SizeId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGenders_ProductGenderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductGenderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_SizeId",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "ProductGenderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "ProductItems");

            migrationBuilder.CreateTable(
                name: "ProductsSizesColours",
                columns: table => new
                {
                    ProductItemId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsSizesColours", x => new { x.ProductItemId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_ProductsSizesColours_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsSizesColours_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductsSizesColours",
                columns: new[] { "ProductItemId", "SizeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsSizesColours_SizeId",
                table: "ProductsSizesColours",
                column: "SizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsSizesColours");

            migrationBuilder.AddColumn<int>(
                name: "ProductGenderId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "ProductItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "SizeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "SizeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "SizeId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGenderId",
                table: "Products",
                column: "ProductGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_SizeId",
                table: "ProductItems",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Sizes_SizeId",
                table: "ProductItems",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGenders_ProductGenderId",
                table: "Products",
                column: "ProductGenderId",
                principalTable: "ProductGenders",
                principalColumn: "Id");
        }
    }
}
