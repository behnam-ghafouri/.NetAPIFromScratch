using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BehnamBehnamAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDutyNumberTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DutyNumbers",
                columns: table => new
                {
                    DutyNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutyNumbers", x => x.DutyNo);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DutyNumbers");

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 7, 17, 57, 6, 777, DateTimeKind.Local).AddTicks(931));

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 17, 57, 6, 777, DateTimeKind.Local).AddTicks(974));

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 9, 17, 57, 6, 777, DateTimeKind.Local).AddTicks(976));

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 17, 57, 6, 777, DateTimeKind.Local).AddTicks(978));

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 11, 17, 57, 6, 777, DateTimeKind.Local).AddTicks(980));
        }
    }
}
