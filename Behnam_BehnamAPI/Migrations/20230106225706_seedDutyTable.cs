using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BehnamBehnamAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedDutyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Duties",
                columns: new[] { "Id", "CreatedDate", "ImageUrl", "Name", "Rate", "Sqft" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 7, 17, 57, 6, 777, DateTimeKind.Local).AddTicks(931), "https://something", "test1", "5", 100 },
                    { 2, new DateTime(2023, 1, 8, 17, 57, 6, 777, DateTimeKind.Local).AddTicks(974), "https://something", "test2", "5", 100 },
                    { 3, new DateTime(2023, 1, 9, 17, 57, 6, 777, DateTimeKind.Local).AddTicks(976), "https://something", "test3", "5", 100 },
                    { 4, new DateTime(2023, 1, 10, 17, 57, 6, 777, DateTimeKind.Local).AddTicks(978), "https://something", "test4", "5", 100 },
                    { 5, new DateTime(2023, 1, 11, 17, 57, 6, 777, DateTimeKind.Local).AddTicks(980), "https://something", "test5", "5", 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
