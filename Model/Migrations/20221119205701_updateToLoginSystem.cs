using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class updateToLoginSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PASSWORD",
                table: "USERS");

            migrationBuilder.AddColumn<string>(
                name: "PASSWORD_HASHED",
                table: "USERS",
                type: "TEXT",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PASSWORD_HASHED",
                table: "USERS");

            migrationBuilder.AddColumn<string>(
                name: "PASSWORD",
                table: "USERS",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
