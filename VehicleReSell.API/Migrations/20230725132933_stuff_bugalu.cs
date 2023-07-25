using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleReSell.API.Migrations
{
    public partial class stuff_bugalu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ToLocationAddress",
                table: "TransferOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FromLocationAddress",
                table: "TransferOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "TransferOrderType",
                table: "TransferOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApproverId",
                table: "SaleOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_ApproverId",
                table: "SaleOrders",
                column: "ApproverId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrders_Users_ApproverId",
                table: "SaleOrders",
                column: "ApproverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrders_Users_ApproverId",
                table: "SaleOrders");

            migrationBuilder.DropIndex(
                name: "IX_SaleOrders_ApproverId",
                table: "SaleOrders");

            migrationBuilder.DropColumn(
                name: "TransferOrderType",
                table: "TransferOrders");

            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "SaleOrders");

            migrationBuilder.AlterColumn<string>(
                name: "ToLocationAddress",
                table: "TransferOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FromLocationAddress",
                table: "TransferOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
