using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.DataBaseRepo.Migrations
{
    /// <inheritdoc />
    public partial class SecondVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "DueDate", "IsCompleted", "Recurrence", "TaskDescription", "TaskName" },
                values: new object[] { 3, new DateTime(2026, 10, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 11, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "None", "Milk, eggs, bread", "Buy groceries" });
        }
    }
}
