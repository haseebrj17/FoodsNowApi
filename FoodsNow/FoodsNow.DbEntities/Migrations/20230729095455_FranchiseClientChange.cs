using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsNow.DbEntities.Migrations
{
    /// <inheritdoc />
    public partial class FranchiseClientChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Franchises",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Franchises_ClientId",
                table: "Franchises",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Franchises_Clients_ClientId",
                table: "Franchises",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Franchises_Clients_ClientId",
                table: "Franchises");

            migrationBuilder.DropIndex(
                name: "IX_Franchises_ClientId",
                table: "Franchises");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Franchises");
        }
    }
}
