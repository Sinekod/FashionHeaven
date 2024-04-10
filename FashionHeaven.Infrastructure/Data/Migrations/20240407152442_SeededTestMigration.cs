using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionHeaven.Data.Migrations
{
    public partial class SeededTestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_SizeCategories_SizeCategoryId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductVariations_ProductVariationId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_SizeCategories_SizeCategoryId",
                table: "Sizes");

            migrationBuilder.DropTable(
                name: "ProductVariations");

            migrationBuilder.DropTable(
                name: "SizeCategories");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_SizeCategoryId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_SizeCategoryId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "SizeCategoryId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "SizeCategoryId",
                table: "ProductCategories");

            migrationBuilder.RenameColumn(
                name: "ProductVariationId",
                table: "ProductImages",
                newName: "ProductItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductVariationId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductItemId");

            migrationBuilder.AddColumn<int>(
                name: "QuantityInStock",
                table: "ProductItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "QuantityInStock", "SizeId" },
                values: new object[] { 50, 1 });

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "QuantityInStock", "SizeId" },
                values: new object[] { 50, 2 });

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "QuantityInStock", "SizeId" },
                values: new object[] { 50, 3 });

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "QuantityInStock", "SizeId" },
                values: new object[] { 50, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_SizeId",
                table: "ProductItems",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductItems_ProductItemId",
                table: "ProductImages",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Sizes_SizeId",
                table: "ProductItems",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductItems_ProductItemId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Sizes_SizeId",
                table: "ProductItems");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_SizeId",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "QuantityInStock",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "ProductItems");

            migrationBuilder.RenameColumn(
                name: "ProductItemId",
                table: "ProductImages",
                newName: "ProductVariationId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductItemId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductVariationId");

            migrationBuilder.AddColumn<int>(
                name: "SizeCategoryId",
                table: "Sizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeCategoryId",
                table: "ProductCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductVariations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductItemId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariations_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariations_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SizeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProductVariations",
                columns: new[] { "Id", "ProductItemId", "QuantityInStock", "SizeId" },
                values: new object[,]
                {
                    { 1, 1, 50, 2 },
                    { 2, 2, 30, 3 },
                    { 3, 3, 25, 1 },
                    { 4, 4, 80, 4 }
                });

            migrationBuilder.InsertData(
                table: "SizeCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "SmallJean" },
                    { 2, "MediumPants" },
                    { 3, "LargeJacket" },
                    { 4, "ExtraLargeShirt" }
                });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "SizeCategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "SizeCategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "SizeCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "SizeCategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "SizeCategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "SizeCategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "SizeCategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "SizeCategoryId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_SizeCategoryId",
                table: "Sizes",
                column: "SizeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_SizeCategoryId",
                table: "ProductCategories",
                column: "SizeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariations_ProductItemId",
                table: "ProductVariations",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariations_SizeId",
                table: "ProductVariations",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_SizeCategories_SizeCategoryId",
                table: "ProductCategories",
                column: "SizeCategoryId",
                principalTable: "SizeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductVariations_ProductVariationId",
                table: "ProductImages",
                column: "ProductVariationId",
                principalTable: "ProductVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_SizeCategories_SizeCategoryId",
                table: "Sizes",
                column: "SizeCategoryId",
                principalTable: "SizeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
