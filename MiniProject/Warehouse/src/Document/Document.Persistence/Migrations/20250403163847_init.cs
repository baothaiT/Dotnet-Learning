using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Document.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DocumentTable",
                columns: new[] { "Id", "Code" },
                values: new object[] { new Guid("3724f12c-411d-40de-ae21-6974cbd1676d"), "Code" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentTable");
        }
    }
}
