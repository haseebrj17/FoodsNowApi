using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsNow.DbEntities.Migrations
{
    /// <inheritdoc />
    public partial class FranchiseIdChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FranchiseId",
                table: "DishOfDays",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FranchiseId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FranchiseId",
                table: "Banners",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FranchiseId",
                table: "Allergies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishOfDays_FranchiseId",
                table: "DishOfDays",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_FranchiseId",
                table: "Categories",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Banners_FranchiseId",
                table: "Banners",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_FranchiseId",
                table: "Allergies",
                column: "FranchiseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergies_Franchises_FranchiseId",
                table: "Allergies",
                column: "FranchiseId",
                principalTable: "Franchises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Franchises_FranchiseId",
                table: "Banners",
                column: "FranchiseId",
                principalTable: "Franchises",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergies_Franchises_FranchiseId",
                table: "Allergies");

            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Franchises_FranchiseId",
                table: "Banners");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Franchises_FranchiseId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOfDays_Franchises_FranchiseId",
                table: "DishOfDays");

            migrationBuilder.DropIndex(
                name: "IX_DishOfDays_FranchiseId",
                table: "DishOfDays");

            migrationBuilder.DropIndex(
                name: "IX_Categories_FranchiseId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Banners_FranchiseId",
                table: "Banners");

            migrationBuilder.DropIndex(
                name: "IX_Allergies_FranchiseId",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "FranchiseId",
                table: "DishOfDays");

            migrationBuilder.DropColumn(
                name: "FranchiseId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "FranchiseId",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "FranchiseId",
                table: "Allergies");
        }
    }
}
