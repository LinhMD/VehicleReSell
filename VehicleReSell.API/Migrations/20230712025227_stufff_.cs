using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleReSell.API.Migrations
{
    public partial class stufff_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "VehicleOwnerId",
                table: "ItemReceipts");
        }
    }
}
