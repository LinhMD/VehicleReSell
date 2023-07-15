using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleReSell.API.Migrations
{
    public partial class syslog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "SystemLogs");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "SystemLogs");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "SystemLogs");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "SystemLogs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SystemLogs");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "SystemLogs");

            migrationBuilder.DropColumn(
                name: "UpdateById",
                table: "SystemLogs");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SystemLogs",
                newName: "User");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "SystemLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "SystemLogs");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "SystemLogs",
                newName: "UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "SystemLogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "SystemLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "SystemLogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeleteById",
                table: "SystemLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "SystemLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "SystemLogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateById",
                table: "SystemLogs",
                type: "int",
                nullable: true);
        }
    }
}
