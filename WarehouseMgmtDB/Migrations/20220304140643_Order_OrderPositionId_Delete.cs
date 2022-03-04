using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMgmtDB.Migrations
{
    public partial class Order_OrderPositionId_Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderPositionsId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderPositionsId",
                table: "Orders",
                type: "int",
                nullable: true);
        }
    }
}
