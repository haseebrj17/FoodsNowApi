using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsNow.DbEntities.Migrations
{
    /// <inheritdoc />
    public partial class FranchiseDataChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Franchises_FranchiseId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOfDays_Franchises_FranchiseId",
                table: "DishOfDays");

            migrationBuilder.AlterColumn<Guid>(
                name: "FranchiseId",
                table: "DishOfDays",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FranchiseId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Franchises_FranchiseId",
                table: "Categories",
                column: "FranchiseId",
                principalTable: "Franchises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOfDays_Franchises_FranchiseId",
                table: "DishOfDays",
                column: "FranchiseId",
                principalTable: "Franchises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Franchises_FranchiseId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOfDays_Franchises_FranchiseId",
                table: "DishOfDays");

            migrationBuilder.AlterColumn<Guid>(
                name: "FranchiseId",
                table: "DishOfDays",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "FranchiseId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Franchises_FranchiseId",
                table: "Categories",
                column: "FranchiseId",
                principalTable: "Franchises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOfDays_Franchises_FranchiseId",
                table: "DishOfDays",
                column: "FranchiseId",
                principalTable: "Franchises",
                principalColumn: "Id");
        }
    }
}
