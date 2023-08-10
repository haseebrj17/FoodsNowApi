using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsNow.DbEntities.Migrations
{
    /// <inheritdoc />
    public partial class ProductExtraDippingAllergyChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductExtraDippingAllergies_Products_ProductId",
                table: "ProductExtraDippingAllergies");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductExtraDippingAllergies",
                newName: "ProductExtraDippingId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductExtraDippingAllergies_ProductId",
                table: "ProductExtraDippingAllergies",
                newName: "IX_ProductExtraDippingAllergies_ProductExtraDippingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductExtraDippingAllergies_ProductExtraDippings_ProductExtraDippingId",
                table: "ProductExtraDippingAllergies",
                column: "ProductExtraDippingId",
                principalTable: "ProductExtraDippings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductExtraDippingAllergies_ProductExtraDippings_ProductExtraDippingId",
                table: "ProductExtraDippingAllergies");

            migrationBuilder.RenameColumn(
                name: "ProductExtraDippingId",
                table: "ProductExtraDippingAllergies",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductExtraDippingAllergies_ProductExtraDippingId",
                table: "ProductExtraDippingAllergies",
                newName: "IX_ProductExtraDippingAllergies_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductExtraDippingAllergies_Products_ProductId",
                table: "ProductExtraDippingAllergies",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
