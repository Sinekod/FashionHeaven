using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionHeaven.Data.Migrations
{
    public partial class ProductImagesChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductItems_ProductItemId",
                table: "ProductImages");

            migrationBuilder.RenameColumn(
                name: "ProductItemId",
                table: "ProductImages",
                newName: "ProductVariationId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductItemId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductVariationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductVariations_ProductVariationId",
                table: "ProductImages",
                column: "ProductVariationId",
                principalTable: "ProductVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductVariations_ProductVariationId",
                table: "ProductImages");

            migrationBuilder.RenameColumn(
                name: "ProductVariationId",
                table: "ProductImages",
                newName: "ProductItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductVariationId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductItems_ProductItemId",
                table: "ProductImages",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
