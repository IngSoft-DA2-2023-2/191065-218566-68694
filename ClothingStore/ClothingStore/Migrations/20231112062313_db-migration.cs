using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStore.Migrations
{
    /// <inheritdoc />
    public partial class dbmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentCategory_PaymentCategoryId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentCategory",
                table: "PaymentCategory");

            migrationBuilder.RenameTable(
                name: "PaymentCategory",
                newName: "PaymentCategories");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentCategories",
                table: "PaymentCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentCategories_PaymentCategoryId",
                table: "Payments",
                column: "PaymentCategoryId",
                principalTable: "PaymentCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentCategories_PaymentCategoryId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentCategories",
                table: "PaymentCategories");

            migrationBuilder.RenameTable(
                name: "PaymentCategories",
                newName: "PaymentCategory");

            migrationBuilder.AlterColumn<Guid>(
                name: "Token",
                table: "Sessions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentCategory",
                table: "PaymentCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentCategory_PaymentCategoryId",
                table: "Payments",
                column: "PaymentCategoryId",
                principalTable: "PaymentCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
