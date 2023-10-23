using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStore.Migrations
{
    /// <inheritdoc />
    public partial class ProductColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ProductId",
                table: "Colors",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Products_ProductId",
                table: "Colors",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Products_ProductId",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Colors_ProductId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Colors");
        }
    }
}
