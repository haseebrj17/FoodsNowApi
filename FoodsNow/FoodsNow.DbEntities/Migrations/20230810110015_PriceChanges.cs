using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsNow.DbEntities.Migrations
{
    /// <inheritdoc />
    public partial class PriceChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductExtraToppings");

            migrationBuilder.AddColumn<bool>(
                name: "showExtraDipping",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ProductExtraDippings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductExtraDippings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductExtraToppingPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,7)", precision: 18, scale: 7, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductExtraToppingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductExtraToppingPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductExtraToppingPrices_ProductExtraToppings_ProductExtraToppingId",
                        column: x => x.ProductExtraToppingId,
                        principalTable: "ProductExtraToppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductExtraDippingPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,7)", precision: 18, scale: 7, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductExtraDippingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductExtraDippingPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductExtraDippingPrices_ProductExtraDippings_ProductExtraDippingId",
                        column: x => x.ProductExtraDippingId,
                        principalTable: "ProductExtraDippings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductExtraDippingPrices_ProductExtraDippingId",
                table: "ProductExtraDippingPrices",
                column: "ProductExtraDippingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductExtraToppingPrices_ProductExtraToppingId",
                table: "ProductExtraToppingPrices",
                column: "ProductExtraToppingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductExtraDippingPrices");

            migrationBuilder.DropTable(
                name: "ProductExtraToppingPrices");

            migrationBuilder.DropTable(
                name: "ProductExtraDippings");

            migrationBuilder.DropColumn(
                name: "showExtraDipping",
                table: "Products");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ProductExtraToppings",
                type: "decimal(18,7)",
                precision: 18,
                scale: 7,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
