using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStore.Migrations
{
    /// <inheritdoc />
    public partial class StateOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateOrder",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateOrder",
                table: "ShoppingCarts");
        }
    }
}
