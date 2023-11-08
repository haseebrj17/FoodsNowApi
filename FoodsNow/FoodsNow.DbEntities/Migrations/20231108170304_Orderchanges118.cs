using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsNow.DbEntities.Migrations
{
    /// <inheritdoc />
    public partial class Orderchanges118 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PriceDetail",
                table: "OrderProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceDetail",
                table: "OrderProductExtraToppings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceDetail",
                table: "OrderProductExtraDippings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceDetail",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "PriceDetail",
                table: "OrderProductExtraToppings");

            migrationBuilder.DropColumn(
                name: "PriceDetail",
                table: "OrderProductExtraDippings");
        }
    }
}
