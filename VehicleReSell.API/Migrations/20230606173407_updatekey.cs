using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleReSell.API.Migrations
{
    public partial class updatekey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessors_Users_CreateById",
                table: "Assessors");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessors_Users_DeleteById",
                table: "Assessors");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessors_Users_UpdateById",
                table: "Assessors");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerEvent_Users_CreateById",
                table: "CustomerEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerEvent_Users_DeleteById",
                table: "CustomerEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerEvent_Users_UpdateById",
                table: "CustomerEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_CreateById",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_DeleteById",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UpdateById",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemReceipts_Users_CreateById",
                table: "ItemReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemReceipts_Users_DeleteById",
                table: "ItemReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemReceipts_Users_UpdateById",
                table: "ItemReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrders_Users_CreateById",
                table: "SaleOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrders_Users_DeleteById",
                table: "SaleOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrders_Users_UpdateById",
                table: "SaleOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Users_CreateById",
                table: "Sellers");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Users_DeleteById",
                table: "Sellers");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Users_UpdateById",
                table: "Sellers");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Users_CreateById",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Users_DeleteById",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Users_UpdateById",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemLogs_Users_CreateById",
                table: "SystemLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemLogs_Users_DeleteById",
                table: "SystemLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemLogs_Users_UpdateById",
                table: "SystemLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLines_Users_CreateById",
                table: "TransactionLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLines_Users_DeleteById",
                table: "TransactionLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLines_Users_UpdateById",
                table: "TransactionLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_CreateById",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_DeleteById",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UpdateById",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferOrders_Users_CreateById",
                table: "TransferOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferOrders_Users_DeleteById",
                table: "TransferOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferOrders_Users_UpdateById",
                table: "TransferOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleOwners_Users_CreateById",
                table: "VehicleOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleOwners_Users_DeleteById",
                table: "VehicleOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleOwners_Users_UpdateById",
                table: "VehicleOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Users_CreateById",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Users_DeleteById",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Users_UpdateById",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_WareHouses_Users_CreateById",
                table: "WareHouses");

            migrationBuilder.DropForeignKey(
                name: "FK_WareHouses_Users_DeleteById",
                table: "WareHouses");

            migrationBuilder.DropForeignKey(
                name: "FK_WareHouses_Users_UpdateById",
                table: "WareHouses");

            migrationBuilder.DropIndex(
                name: "IX_WareHouses_CreateById",
                table: "WareHouses");

            migrationBuilder.DropIndex(
                name: "IX_WareHouses_DeleteById",
                table: "WareHouses");

            migrationBuilder.DropIndex(
                name: "IX_WareHouses_UpdateById",
                table: "WareHouses");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CreateById",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_DeleteById",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_UpdateById",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_VehicleOwners_CreateById",
                table: "VehicleOwners");

            migrationBuilder.DropIndex(
                name: "IX_VehicleOwners_DeleteById",
                table: "VehicleOwners");

            migrationBuilder.DropIndex(
                name: "IX_VehicleOwners_UpdateById",
                table: "VehicleOwners");

            migrationBuilder.DropIndex(
                name: "IX_TransferOrders_CreateById",
                table: "TransferOrders");

            migrationBuilder.DropIndex(
                name: "IX_TransferOrders_DeleteById",
                table: "TransferOrders");

            migrationBuilder.DropIndex(
                name: "IX_TransferOrders_UpdateById",
                table: "TransferOrders");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CreateById",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_DeleteById",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UpdateById",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_TransactionLines_CreateById",
                table: "TransactionLines");

            migrationBuilder.DropIndex(
                name: "IX_TransactionLines_DeleteById",
                table: "TransactionLines");

            migrationBuilder.DropIndex(
                name: "IX_TransactionLines_UpdateById",
                table: "TransactionLines");

            migrationBuilder.DropIndex(
                name: "IX_SystemLogs_CreateById",
                table: "SystemLogs");

            migrationBuilder.DropIndex(
                name: "IX_SystemLogs_DeleteById",
                table: "SystemLogs");

            migrationBuilder.DropIndex(
                name: "IX_SystemLogs_UpdateById",
                table: "SystemLogs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_CreateById",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_DeleteById",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_UpdateById",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Sellers_CreateById",
                table: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Sellers_DeleteById",
                table: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Sellers_UpdateById",
                table: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_SaleOrders_CreateById",
                table: "SaleOrders");

            migrationBuilder.DropIndex(
                name: "IX_SaleOrders_DeleteById",
                table: "SaleOrders");

            migrationBuilder.DropIndex(
                name: "IX_SaleOrders_UpdateById",
                table: "SaleOrders");

            migrationBuilder.DropIndex(
                name: "IX_ItemReceipts_CreateById",
                table: "ItemReceipts");

            migrationBuilder.DropIndex(
                name: "IX_ItemReceipts_DeleteById",
                table: "ItemReceipts");

            migrationBuilder.DropIndex(
                name: "IX_ItemReceipts_UpdateById",
                table: "ItemReceipts");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CreateById",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_DeleteById",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UpdateById",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_CustomerEvent_CreateById",
                table: "CustomerEvent");

            migrationBuilder.DropIndex(
                name: "IX_CustomerEvent_DeleteById",
                table: "CustomerEvent");

            migrationBuilder.DropIndex(
                name: "IX_CustomerEvent_UpdateById",
                table: "CustomerEvent");

            migrationBuilder.DropIndex(
                name: "IX_Assessors_CreateById",
                table: "Assessors");

            migrationBuilder.DropIndex(
                name: "IX_Assessors_DeleteById",
                table: "Assessors");

            migrationBuilder.DropIndex(
                name: "IX_Assessors_UpdateById",
                table: "Assessors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WareHouses_CreateById",
                table: "WareHouses",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouses_DeleteById",
                table: "WareHouses",
                column: "DeleteById");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouses_UpdateById",
                table: "WareHouses",
                column: "UpdateById");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CreateById",
                table: "Vehicles",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DeleteById",
                table: "Vehicles",
                column: "DeleteById");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UpdateById",
                table: "Vehicles",
                column: "UpdateById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOwners_CreateById",
                table: "VehicleOwners",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOwners_DeleteById",
                table: "VehicleOwners",
                column: "DeleteById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOwners_UpdateById",
                table: "VehicleOwners",
                column: "UpdateById");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrders_CreateById",
                table: "TransferOrders",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrders_DeleteById",
                table: "TransferOrders",
                column: "DeleteById");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrders_UpdateById",
                table: "TransferOrders",
                column: "UpdateById");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CreateById",
                table: "Transactions",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DeleteById",
                table: "Transactions",
                column: "DeleteById");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UpdateById",
                table: "Transactions",
                column: "UpdateById");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLines_CreateById",
                table: "TransactionLines",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLines_DeleteById",
                table: "TransactionLines",
                column: "DeleteById");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLines_UpdateById",
                table: "TransactionLines",
                column: "UpdateById");

            migrationBuilder.CreateIndex(
                name: "IX_SystemLogs_CreateById",
                table: "SystemLogs",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_SystemLogs_DeleteById",
                table: "SystemLogs",
                column: "DeleteById");

            migrationBuilder.CreateIndex(
                name: "IX_SystemLogs_UpdateById",
                table: "SystemLogs",
                column: "UpdateById");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_CreateById",
                table: "Staffs",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DeleteById",
                table: "Staffs",
                column: "DeleteById");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_UpdateById",
                table: "Staffs",
                column: "UpdateById");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_CreateById",
                table: "Sellers",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_DeleteById",
                table: "Sellers",
                column: "DeleteById");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_UpdateById",
                table: "Sellers",
                column: "UpdateById");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_CreateById",
                table: "SaleOrders",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_DeleteById",
                table: "SaleOrders",
                column: "DeleteById");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_UpdateById",
                table: "SaleOrders",
                column: "UpdateById");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReceipts_CreateById",
                table: "ItemReceipts",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReceipts_DeleteById",
                table: "ItemReceipts",
                column: "DeleteById");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReceipts_UpdateById",
                table: "ItemReceipts",
                column: "UpdateById");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CreateById",
                table: "Customers",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DeleteById",
                table: "Customers",
                column: "DeleteById");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UpdateById",
                table: "Customers",
                column: "UpdateById");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEvent_CreateById",
                table: "CustomerEvent",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEvent_DeleteById",
                table: "CustomerEvent",
                column: "DeleteById");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEvent_UpdateById",
                table: "CustomerEvent",
                column: "UpdateById");

            migrationBuilder.CreateIndex(
                name: "IX_Assessors_CreateById",
                table: "Assessors",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Assessors_DeleteById",
                table: "Assessors",
                column: "DeleteById");

            migrationBuilder.CreateIndex(
                name: "IX_Assessors_UpdateById",
                table: "Assessors",
                column: "UpdateById");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessors_Users_CreateById",
                table: "Assessors",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessors_Users_DeleteById",
                table: "Assessors",
                column: "DeleteById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessors_Users_UpdateById",
                table: "Assessors",
                column: "UpdateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerEvent_Users_CreateById",
                table: "CustomerEvent",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerEvent_Users_DeleteById",
                table: "CustomerEvent",
                column: "DeleteById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerEvent_Users_UpdateById",
                table: "CustomerEvent",
                column: "UpdateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_CreateById",
                table: "Customers",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_DeleteById",
                table: "Customers",
                column: "DeleteById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UpdateById",
                table: "Customers",
                column: "UpdateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReceipts_Users_CreateById",
                table: "ItemReceipts",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReceipts_Users_DeleteById",
                table: "ItemReceipts",
                column: "DeleteById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReceipts_Users_UpdateById",
                table: "ItemReceipts",
                column: "UpdateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrders_Users_CreateById",
                table: "SaleOrders",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrders_Users_DeleteById",
                table: "SaleOrders",
                column: "DeleteById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrders_Users_UpdateById",
                table: "SaleOrders",
                column: "UpdateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Users_CreateById",
                table: "Sellers",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Users_DeleteById",
                table: "Sellers",
                column: "DeleteById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Users_UpdateById",
                table: "Sellers",
                column: "UpdateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Users_CreateById",
                table: "Staffs",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Users_DeleteById",
                table: "Staffs",
                column: "DeleteById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Users_UpdateById",
                table: "Staffs",
                column: "UpdateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemLogs_Users_CreateById",
                table: "SystemLogs",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemLogs_Users_DeleteById",
                table: "SystemLogs",
                column: "DeleteById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemLogs_Users_UpdateById",
                table: "SystemLogs",
                column: "UpdateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLines_Users_CreateById",
                table: "TransactionLines",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLines_Users_DeleteById",
                table: "TransactionLines",
                column: "DeleteById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLines_Users_UpdateById",
                table: "TransactionLines",
                column: "UpdateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_CreateById",
                table: "Transactions",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_DeleteById",
                table: "Transactions",
                column: "DeleteById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UpdateById",
                table: "Transactions",
                column: "UpdateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferOrders_Users_CreateById",
                table: "TransferOrders",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferOrders_Users_DeleteById",
                table: "TransferOrders",
                column: "DeleteById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferOrders_Users_UpdateById",
                table: "TransferOrders",
                column: "UpdateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleOwners_Users_CreateById",
                table: "VehicleOwners",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleOwners_Users_DeleteById",
                table: "VehicleOwners",
                column: "DeleteById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleOwners_Users_UpdateById",
                table: "VehicleOwners",
                column: "UpdateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Users_CreateById",
                table: "Vehicles",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Users_DeleteById",
                table: "Vehicles",
                column: "DeleteById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Users_UpdateById",
                table: "Vehicles",
                column: "UpdateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WareHouses_Users_CreateById",
                table: "WareHouses",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WareHouses_Users_DeleteById",
                table: "WareHouses",
                column: "DeleteById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WareHouses_Users_UpdateById",
                table: "WareHouses",
                column: "UpdateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
