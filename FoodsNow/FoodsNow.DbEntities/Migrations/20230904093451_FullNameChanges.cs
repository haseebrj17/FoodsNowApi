using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsNow.DbEntities.Migrations
{
    /// <inheritdoc />
    public partial class FullNameChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerAdresses_CustomerAdressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerAdressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerAdressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "FullName");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "CustomerAdresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerAddressId",
                table: "Orders",
                column: "CustomerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAdresses_CustomerId",
                table: "CustomerAdresses",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAdresses_Customers_CustomerId",
                table: "CustomerAdresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerAdresses_CustomerAddressId",
                table: "Orders",
                column: "CustomerAddressId",
                principalTable: "CustomerAdresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAdresses_Customers_CustomerId",
                table: "CustomerAdresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerAdresses_CustomerAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAdresses_CustomerId",
                table: "CustomerAdresses");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerAdresses");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerAdressId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerAdressId",
                table: "Orders",
                column: "CustomerAdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerAdresses_CustomerAdressId",
                table: "Orders",
                column: "CustomerAdressId",
                principalTable: "CustomerAdresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
