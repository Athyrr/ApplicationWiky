using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class jsp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 1, 12, 10, 56, 46, 386, DateTimeKind.Local).AddTicks(7027), new DateTime(2024, 1, 12, 10, 56, 46, 386, DateTimeKind.Local).AddTicks(7069) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 1, 12, 9, 23, 29, 609, DateTimeKind.Local).AddTicks(6063), new DateTime(2024, 1, 12, 9, 23, 29, 609, DateTimeKind.Local).AddTicks(6100) });
        }
    }
}
