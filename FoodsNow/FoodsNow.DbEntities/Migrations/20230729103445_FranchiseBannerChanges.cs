using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsNow.DbEntities.Migrations
{
    /// <inheritdoc />
    public partial class FranchiseBannerChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergies_Franchises_FranchiseId",
                table: "Allergies");

            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Franchises_FranchiseId",
                table: "Banners");

            migrationBuilder.AlterColumn<Guid>(
                name: "FranchiseId",
                table: "Banners",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FranchiseId",
                table: "Allergies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Allergies_Franchises_FranchiseId",
                table: "Allergies",
                column: "FranchiseId",
                principalTable: "Franchises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Franchises_FranchiseId",
                table: "Banners",
                column: "FranchiseId",
                principalTable: "Franchises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.AlterColumn<Guid>(
                name: "FranchiseId",
                table: "Banners",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "FranchiseId",
                table: "Allergies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
        }
    }
}
