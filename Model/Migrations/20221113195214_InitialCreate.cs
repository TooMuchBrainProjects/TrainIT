using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PRESETS",
                columns: table => new
                {
                    PRESET_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRESETS", x => x.PRESET_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PASSWORD = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.USER_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EXERCISES",
                columns: table => new
                {
                    EXERCISE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MACHINE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "TEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXERCISES", x => x.EXERCISE_ID);
                    table.ForeignKey(
                        name: "FK_EXERCISES_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PRESET_HAS_EXERCISES_JT",
                columns: table => new
                {
                    PRESET_ID = table.Column<int>(type: "int", nullable: false),
                    EXERCISE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRESET_HAS_EXERCISES_JT", x => new { x.EXERCISE_ID, x.PRESET_ID });
                    table.ForeignKey(
                        name: "FK_PRESET_HAS_EXERCISES_JT_EXERCISES_EXERCISE_ID",
                        column: x => x.EXERCISE_ID,
                        principalTable: "EXERCISES",
                        principalColumn: "EXERCISE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRESET_HAS_EXERCISES_JT_PRESETS_PRESET_ID",
                        column: x => x.PRESET_ID,
                        principalTable: "PRESETS",
                        principalColumn: "PRESET_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SUB_EXERCISES",
                columns: table => new
                {
                    SUB_EXERCISE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EXERCISE_ID = table.Column<int>(type: "int", nullable: false),
                    DATE = table.Column<DateOnly>(type: "date", nullable: false),
                    WEIGHT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    REPETITION = table.Column<int>(type: "int", nullable: false),
                    SET = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUB_EXERCISES", x => x.SUB_EXERCISE_ID);
                    table.ForeignKey(
                        name: "FK_SUB_EXERCISES_EXERCISES_EXERCISE_ID",
                        column: x => x.EXERCISE_ID,
                        principalTable: "EXERCISES",
                        principalColumn: "EXERCISE_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EXERCISES_USER_ID",
                table: "EXERCISES",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRESET_HAS_EXERCISES_JT_PRESET_ID",
                table: "PRESET_HAS_EXERCISES_JT",
                column: "PRESET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUB_EXERCISES_EXERCISE_ID",
                table: "SUB_EXERCISES",
                column: "EXERCISE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_EMAIL",
                table: "USERS",
                column: "EMAIL",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRESET_HAS_EXERCISES_JT");

            migrationBuilder.DropTable(
                name: "SUB_EXERCISES");

            migrationBuilder.DropTable(
                name: "PRESETS");

            migrationBuilder.DropTable(
                name: "EXERCISES");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
