using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class datesNamesCHanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EditionDate",
                table: "Comments",
                newName: "EditedAt");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Comments",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "EditionDate",
                table: "Articles",
                newName: "EditedAt");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Articles",
                newName: "CreatedAt");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 1, 11, 17, 40, 21, 707, DateTimeKind.Local).AddTicks(4527), new DateTime(2024, 1, 11, 17, 40, 21, 707, DateTimeKind.Local).AddTicks(4576) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EditedAt",
                table: "Comments",
                newName: "EditionDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Comments",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "EditedAt",
                table: "Articles",
                newName: "EditionDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Articles",
                newName: "CreationDate");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "EditionDate" },
                values: new object[] { new DateTime(2024, 1, 11, 17, 3, 42, 354, DateTimeKind.Local).AddTicks(9774), new DateTime(2024, 1, 11, 17, 3, 42, 354, DateTimeKind.Local).AddTicks(9826) });
        }
    }
}
