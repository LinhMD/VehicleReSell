using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleReSell.API.Migrations
{
    public partial class warehouse_stuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentCapacity",
                table: "WareHouses");

            migrationBuilder.AddColumn<int>(
                name: "AvailableCapacity",
                table: "WareHouses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "WareHouses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableCapacity",
                table: "WareHouses");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "WareHouses");

            migrationBuilder.AddColumn<int>(
                name: "CurrentCapacity",
                table: "WareHouses",
                type: "int",
                nullable: true);
        }
    }
}
