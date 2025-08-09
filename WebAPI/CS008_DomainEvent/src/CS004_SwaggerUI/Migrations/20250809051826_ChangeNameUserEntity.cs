using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS004_SwaggerUI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vocabularies",
                table: "Vocabularies");

            migrationBuilder.RenameTable(
                name: "Vocabularies",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Vocabularies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vocabularies",
                table: "Vocabularies",
                column: "Id");
        }
    }
}
