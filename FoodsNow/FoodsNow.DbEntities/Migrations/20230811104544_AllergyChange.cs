using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsNow.DbEntities.Migrations
{
    /// <inheritdoc />
    public partial class AllergyChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "Allergies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "Allergies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_ProductId1",
                table: "Allergies",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergies_Products_ProductId1",
                table: "Allergies",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergies_Products_ProductId1",
                table: "Allergies");

            migrationBuilder.DropIndex(
                name: "IX_Allergies_ProductId1",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Allergies");
        }
    }
}
