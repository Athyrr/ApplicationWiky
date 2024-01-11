using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_Id",
                        column: x => x.Id,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Author", "Content", "CreationDate", "EditionDate", "Theme" },
                values: new object[] { 1, "Author 1", "Content 1", new DateTime(2024, 1, 11, 17, 3, 42, 354, DateTimeKind.Local).AddTicks(9774), new DateTime(2024, 1, 11, 17, 3, 42, 354, DateTimeKind.Local).AddTicks(9826), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
