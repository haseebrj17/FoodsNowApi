using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsNow.DbEntities.Migrations
{
    /// <inheritdoc />
    public partial class OrderChanges1209212 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Intructions",
                table: "Orders",
                newName: "Instructions");

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Instructions",
                table: "Orders",
                newName: "Intructions");
        }
    }
}
