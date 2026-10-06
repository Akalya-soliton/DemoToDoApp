using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoApp.DataBaseRepo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskName = table.Column<string>(type: "TEXT", nullable: false),
                    TaskDescription = table.Column<string>(type: "TEXT", nullable: true),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Recurrence = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "DueDate", "IsCompleted", "Recurrence", "TaskDescription", "TaskName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "Daily", "Balcony plants", "Water plants" },
                    { 2, new DateTime(2026, 10, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "Weekly", "Weekly status meeting", "Team sync" },
                    { 3, new DateTime(2026, 10, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 11, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "None", "Milk, eggs, bread", "Buy groceries" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
