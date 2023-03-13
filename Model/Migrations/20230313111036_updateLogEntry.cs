using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class updateLogEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DATE",
                table: "LOG_ENTRIES",
                newName: "CHANGE_DATE");

            migrationBuilder.AddColumn<string>(
                name: "NEW_VALUE",
                table: "LOG_ENTRIES",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OLD_VALUE",
                table: "LOG_ENTRIES",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NEW_VALUE",
                table: "LOG_ENTRIES");

            migrationBuilder.DropColumn(
                name: "OLD_VALUE",
                table: "LOG_ENTRIES");

            migrationBuilder.RenameColumn(
                name: "CHANGE_DATE",
                table: "LOG_ENTRIES",
                newName: "DATE");
        }
    }
}
