using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BehnamBehnamAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateDutyNumberTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DutyNumbers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DutyNumbers");

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 15, 16, 34, 980, DateTimeKind.Local).AddTicks(1734));

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 9, 15, 16, 34, 980, DateTimeKind.Local).AddTicks(1788));

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 15, 16, 34, 980, DateTimeKind.Local).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 15, 16, 34, 980, DateTimeKind.Local).AddTicks(1795));

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 12, 15, 16, 34, 980, DateTimeKind.Local).AddTicks(1798));
        }
    }
}
