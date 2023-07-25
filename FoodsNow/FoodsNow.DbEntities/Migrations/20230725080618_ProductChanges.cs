using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsNow.DbEntities.Migrations
{
    /// <inheritdoc />
    public partial class ProductChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IngredientDetail",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IngredientSummary",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientDetail",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IngredientSummary",
                table: "Products");
        }
    }
}
