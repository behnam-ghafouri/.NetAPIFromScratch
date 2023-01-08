using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BehnamBehnamAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddForigenKeyToDutyNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DutyId",
                table: "DutyNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 16, 5, 58, 346, DateTimeKind.Local).AddTicks(383));

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 9, 16, 5, 58, 346, DateTimeKind.Local).AddTicks(438));

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 16, 5, 58, 346, DateTimeKind.Local).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 16, 5, 58, 346, DateTimeKind.Local).AddTicks(443));

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 12, 16, 5, 58, 346, DateTimeKind.Local).AddTicks(446));

            migrationBuilder.CreateIndex(
                name: "IX_DutyNumbers_DutyId",
                table: "DutyNumbers",
                column: "DutyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DutyNumbers_Duties_DutyId",
                table: "DutyNumbers",
                column: "DutyId",
                principalTable: "Duties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DutyNumbers_Duties_DutyId",
                table: "DutyNumbers");

            migrationBuilder.DropIndex(
                name: "IX_DutyNumbers_DutyId",
                table: "DutyNumbers");

            migrationBuilder.DropColumn(
                name: "DutyId",
                table: "DutyNumbers");

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 15, 54, 19, 984, DateTimeKind.Local).AddTicks(1187));

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 9, 15, 54, 19, 984, DateTimeKind.Local).AddTicks(1237));

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 15, 54, 19, 984, DateTimeKind.Local).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 15, 54, 19, 984, DateTimeKind.Local).AddTicks(1242));

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 12, 15, 54, 19, 984, DateTimeKind.Local).AddTicks(1245));
        }
    }
}
