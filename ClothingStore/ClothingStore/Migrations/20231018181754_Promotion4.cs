using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStore.Migrations
{
    /// <inheritdoc />
    public partial class Promotion4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PromotionId",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_PromotionId",
                table: "ShoppingCarts",
                column: "PromotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Promotions_PromotionId",
                table: "ShoppingCarts",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Promotions_PromotionId",
                table: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_PromotionId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "ShoppingCarts");
        }
    }
}
