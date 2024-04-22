using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionHeaven.Data.Migrations
{
    public partial class SizesAndColoursAreOneNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Colours_ColourId",
                table: "ProductItems");

            migrationBuilder.DropTable(
                name: "ProductsSizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_ColourId",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "ColourId",
                table: "ProductItems");

            migrationBuilder.CreateTable(
                name: "ProductsSizesColours",
                columns: table => new
                {
                    ProductItemId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    ColourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsSizesColours", x => new { x.ProductItemId, x.SizeId, x.ColourId });
                    table.ForeignKey(
                        name: "FK_ProductsSizesColours_Colours_ColourId",
                        column: x => x.ColourId,
                        principalTable: "Colours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "ColourId", "ProductItemId", "SizeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 5, 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsSizesColours_ColourId",
                table: "ProductsSizesColours",
                column: "ColourId");

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
                name: "ColourId",
                table: "ProductItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductsSizes",
                columns: table => new
                {
                    ProductItemId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsSizes", x => new { x.ProductItemId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_ProductsSizes_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ColourId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ColourId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ColourId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ColourId",
                value: 5);

            migrationBuilder.InsertData(
                table: "ProductsSizes",
                columns: new[] { "ProductItemId", "SizeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ColourId",
                table: "ProductItems",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsSizes_SizeId",
                table: "ProductsSizes",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Colours_ColourId",
                table: "ProductItems",
                column: "ColourId",
                principalTable: "Colours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
