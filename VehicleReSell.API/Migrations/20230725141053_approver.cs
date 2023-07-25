using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleReSell.API.Migrations
{
    public partial class approver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApproverId",
                table: "TransferOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrders_ApproverId",
                table: "TransferOrders",
                column: "ApproverId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferOrders_Users_ApproverId",
                table: "TransferOrders",
                column: "ApproverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferOrders_Users_ApproverId",
                table: "TransferOrders");

            migrationBuilder.DropIndex(
                name: "IX_TransferOrders_ApproverId",
                table: "TransferOrders");

            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "TransferOrders");
        }
    }
}
