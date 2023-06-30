using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreAuditFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "LeaveTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "LeaveTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "LeaveAllocations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "LeaveAllocations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "DateCreated", "DateModified", "ModifiedBy" },
                values: new object[] { null, new DateTime(2023, 6, 30, 18, 13, 21, 713, DateTimeKind.Local).AddTicks(4350), new DateTime(2023, 6, 30, 18, 13, 21, 713, DateTimeKind.Local).AddTicks(4362), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LeaveTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "LeaveTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LeaveAllocations");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 10, 19, 13, 26, 908, DateTimeKind.Local).AddTicks(4980), new DateTime(2023, 5, 10, 19, 13, 26, 908, DateTimeKind.Local).AddTicks(4994) });
        }
    }
}
