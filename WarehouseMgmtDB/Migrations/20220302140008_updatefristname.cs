using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseMgmtDB.Migrations
{
    public partial class updatefristname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FristName",
                table: "Customers",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "FristName");
        }
    }
}
