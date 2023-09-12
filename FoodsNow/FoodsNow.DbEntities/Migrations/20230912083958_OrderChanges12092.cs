using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsNow.DbEntities.Migrations
{
    /// <inheritdoc />
    public partial class OrderChanges12092 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalItems",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalItems",
                table: "Orders");
        }
    }
}
