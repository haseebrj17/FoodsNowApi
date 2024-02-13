﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsNow.DbEntities.Migrations
{
    /// <inheritdoc />
    public partial class Orderchanges811 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductExtraDippings_ProductExtraDippingPrices_ProductExtraDippingPriceId",
                table: "OrderProductExtraDippings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductExtraToppings_ProductExtraToppingPrices_ProductExtraToppingPriceId",
                table: "OrderProductExtraToppings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_ProductPrices_ProductPriceId",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_ProductPriceId",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductExtraToppings_ProductExtraToppingPriceId",
                table: "OrderProductExtraToppings");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductExtraDippings_ProductExtraDippingPriceId",
                table: "OrderProductExtraDippings");

            migrationBuilder.DropColumn(
                name: "ProductPriceId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "ProductExtraToppingPriceId",
                table: "OrderProductExtraToppings");

            migrationBuilder.DropColumn(
                name: "ProductExtraDippingPriceId",
                table: "OrderProductExtraDippings");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderProductExtraToppings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderProductExtraDippings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderProductExtraToppings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderProductExtraDippings");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductPriceId",
                table: "OrderProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductExtraToppingPriceId",
                table: "OrderProductExtraToppings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductExtraDippingPriceId",
                table: "OrderProductExtraDippings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductPriceId",
                table: "OrderProducts",
                column: "ProductPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductExtraToppings_ProductExtraToppingPriceId",
                table: "OrderProductExtraToppings",
                column: "ProductExtraToppingPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductExtraDippings_ProductExtraDippingPriceId",
                table: "OrderProductExtraDippings",
                column: "ProductExtraDippingPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductExtraDippings_ProductExtraDippingPrices_ProductExtraDippingPriceId",
                table: "OrderProductExtraDippings",
                column: "ProductExtraDippingPriceId",
                principalTable: "ProductExtraDippingPrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductExtraToppings_ProductExtraToppingPrices_ProductExtraToppingPriceId",
                table: "OrderProductExtraToppings",
                column: "ProductExtraToppingPriceId",
                principalTable: "ProductExtraToppingPrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_ProductPrices_ProductPriceId",
                table: "OrderProducts",
                column: "ProductPriceId",
                principalTable: "ProductPrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}