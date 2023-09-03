using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsNow.DbEntities.Migrations
{
    /// <inheritdoc />
    public partial class VerificationPinChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "house",
                table: "CustomerAdresses",
                newName: "House");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "CustomerAdresses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "CustomerAdresses");

            migrationBuilder.RenameColumn(
                name: "House",
                table: "CustomerAdresses",
                newName: "house");
        }
    }
}
