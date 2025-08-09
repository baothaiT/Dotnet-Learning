using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CS004_SwaggerUI.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vocabularies",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "Status", "Username" },
                values: new object[,]
                {
                    { "user-001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "john.doe@example.com", "hashedpassword123", 1, "john_doe" },
                    { "user-002", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "jane.smith@example.com", "hashedpassword456", 1, "jane_smith" },
                    { "user-003", new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "bob.wilson@example.com", "hashedpassword789", 0, "bob_wilson" },
                    { "user-004", new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "alice.brown@example.com", "hashedpassword101", 2, "alice_brown" },
                    { "user-005", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "charlie.davis@example.com", "hashedpassword102", 1, "charlie_davis" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "Id",
                keyValue: "user-001");

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "Id",
                keyValue: "user-002");

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "Id",
                keyValue: "user-003");

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "Id",
                keyValue: "user-004");

            migrationBuilder.DeleteData(
                table: "Vocabularies",
                keyColumn: "Id",
                keyValue: "user-005");
        }
    }
}
