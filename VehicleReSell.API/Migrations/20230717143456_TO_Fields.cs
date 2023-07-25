using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleReSell.API.Migrations
{
    public partial class TO_Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemReceiptId",
                table: "TransferOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaleOrderId",
                table: "TransferOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrders_ItemReceiptId",
                table: "TransferOrders",
                column: "ItemReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrders_SaleOrderId",
                table: "TransferOrders",
                column: "SaleOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferOrders_ItemReceipts_ItemReceiptId",
                table: "TransferOrders",
                column: "ItemReceiptId",
                principalTable: "ItemReceipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferOrders_SaleOrders_SaleOrderId",
                table: "TransferOrders",
                column: "SaleOrderId",
                principalTable: "SaleOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferOrders_ItemReceipts_ItemReceiptId",
                table: "TransferOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferOrders_SaleOrders_SaleOrderId",
                table: "TransferOrders");

            migrationBuilder.DropIndex(
                name: "IX_TransferOrders_ItemReceiptId",
                table: "TransferOrders");

            migrationBuilder.DropIndex(
                name: "IX_TransferOrders_SaleOrderId",
                table: "TransferOrders");

            migrationBuilder.DropColumn(
                name: "ItemReceiptId",
                table: "TransferOrders");

            migrationBuilder.DropColumn(
                name: "SaleOrderId",
                table: "TransferOrders");
        }
    }
}
