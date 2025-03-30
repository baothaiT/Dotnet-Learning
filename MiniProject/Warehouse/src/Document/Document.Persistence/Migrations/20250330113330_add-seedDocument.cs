using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Document.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addseedDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DocumentTable",
                columns: new[] { "Id", "Code" },
                values: new object[] { new Guid("ab7353ca-2e10-4f36-90ea-c4aa8e21c82f"), "Code" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DocumentTable",
                keyColumn: "Id",
                keyValue: new Guid("ab7353ca-2e10-4f36-90ea-c4aa8e21c82f"));
        }
    }
}
