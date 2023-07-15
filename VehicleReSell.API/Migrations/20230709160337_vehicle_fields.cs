using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleReSell.API.Migrations
{
    public partial class vehicle_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuelType",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GearType",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManufactureYear",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleOwnerId",
                table: "ItemReceipts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemReceipts_VehicleOwnerId",
                table: "ItemReceipts",
                column: "VehicleOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReceipts_VehicleOwners_VehicleOwnerId",
                table: "ItemReceipts",
                column: "VehicleOwnerId",
                principalTable: "VehicleOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemReceipts_VehicleOwners_VehicleOwnerId",
                table: "ItemReceipts");

            migrationBuilder.DropIndex(
                name: "IX_ItemReceipts_VehicleOwnerId",
                table: "ItemReceipts");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "GearType",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ManufactureYear",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleOwnerId",
                table: "ItemReceipts");
        }
    }
}
