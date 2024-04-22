using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionHeaven.Data.Migrations
{
    public partial class NoMoreImgTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsSizesColours_ProductItems_ProductItemId",
                table: "ProductsSizesColours");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsSizesColours_Sizes_SizeId",
                table: "ProductsSizesColours");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsSizesColours",
                table: "ProductsSizesColours");

            migrationBuilder.RenameTable(
                name: "ProductsSizesColours",
                newName: "ProductsSizes");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsSizesColours_SizeId",
                table: "ProductsSizes",
                newName: "IX_ProductsSizes_SizeId");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "ProductItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsSizes",
                table: "ProductsSizes",
                columns: new[] { "ProductItemId", "SizeId" });

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "https://www.asphaltgold.com/cdn/shop/files/e28c112df2824d87e6d428611d0d7b2dfb59d2c0_FB7368_657_Nike_Club_Puffer_Jacket_University_Red_White_os_1_1200x1200.jpg?v=1707749646");

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "https://static.ftshp.digital/img/p/1/0/7/2/5/7/3/1072573-full_product.jpg");

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "https://i.ebayimg.com/images/g/gq4AAOSwj29i9Hmg/s-l1600.jpg");

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgUrl",
                value: "https://images.hugoboss.com/is/image/boss/hbeu50501329_015_100?$re_fullPageZoom$&qlt=85&fit=crop,1&align=1,1&lastModified=1705957483000&wid=1200&hei=1818");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsSizes_ProductItems_ProductItemId",
                table: "ProductsSizes",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsSizes_Sizes_SizeId",
                table: "ProductsSizes",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsSizes_ProductItems_ProductItemId",
                table: "ProductsSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsSizes_Sizes_SizeId",
                table: "ProductsSizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsSizes",
                table: "ProductsSizes");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "ProductItems");

            migrationBuilder.RenameTable(
                name: "ProductsSizes",
                newName: "ProductsSizesColours");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsSizes_SizeId",
                table: "ProductsSizesColours",
                newName: "IX_ProductsSizesColours_SizeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsSizesColours",
                table: "ProductsSizesColours",
                columns: new[] { "ProductItemId", "SizeId" });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductItemId = table.Column<int>(type: "int", nullable: false),
                    UmgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ProductItemId", "UmgUrl" },
                values: new object[,]
                {
                    { 1, 1, "https://www.asphaltgold.com/cdn/shop/files/e28c112df2824d87e6d428611d0d7b2dfb59d2c0_FB7368_657_Nike_Club_Puffer_Jacket_University_Red_White_os_1_1200x1200.jpg?v=1707749646" },
                    { 2, 2, "https://static.ftshp.digital/img/p/1/0/7/2/5/7/3/1072573-full_product.jpg" },
                    { 3, 3, "https://i.ebayimg.com/images/g/gq4AAOSwj29i9Hmg/s-l1600.jpg" },
                    { 4, 4, "https://images.hugoboss.com/is/image/boss/hbeu50501329_015_100?$re_fullPageZoom$&qlt=85&fit=crop,1&align=1,1&lastModified=1705957483000&wid=1200&hei=1818" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductItemId",
                table: "ProductImages",
                column: "ProductItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsSizesColours_ProductItems_ProductItemId",
                table: "ProductsSizesColours",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsSizesColours_Sizes_SizeId",
                table: "ProductsSizesColours",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
