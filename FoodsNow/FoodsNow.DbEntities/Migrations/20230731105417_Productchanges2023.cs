using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsNow.DbEntities.Migrations
{
    /// <inheritdoc />
    public partial class Productchanges2023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WebsiteLogo",
                table: "Categories",
                newName: "Thumbnail");

            migrationBuilder.RenameColumn(
                name: "AppLogo",
                table: "Categories",
                newName: "Cover");

            migrationBuilder.AddColumn<string>(
                name: "EstimatedDeliveryTime",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpiceLevel",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBrand",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedDeliveryTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SpiceLevel",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsBrand",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Thumbnail",
                table: "Categories",
                newName: "WebsiteLogo");

            migrationBuilder.RenameColumn(
                name: "Cover",
                table: "Categories",
                newName: "AppLogo");
        }
    }
}
