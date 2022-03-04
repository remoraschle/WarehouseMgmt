﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMgmtDB.Migrations
{
    public partial class OrderPositionId_NullAble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderPositions_OrderPositionsId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "OrderPositionsId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderPositions_OrderPositionsId",
                table: "Orders",
                column: "OrderPositionsId",
                principalTable: "OrderPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderPositions_OrderPositionsId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "OrderPositionsId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderPositions_OrderPositionsId",
                table: "Orders",
                column: "OrderPositionsId",
                principalTable: "OrderPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
