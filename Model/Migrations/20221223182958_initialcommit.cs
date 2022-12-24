using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class initialcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
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
                    PASSWORD_HASHED = table.Column<string>(type: "TEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.USER_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WORKOUTS",
                columns: table => new
                {
                    WORKOUT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKOUTS", x => x.WORKOUT_ID);
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
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: false)
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
                name: "ACTIVITIES",
                columns: table => new
                {
                    ACTIVITY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EXERCISE_ID = table.Column<int>(type: "int", nullable: false),
                    DATE = table.Column<DateOnly>(type: "date", nullable: false),
                    WEIGHT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    REPETITION = table.Column<int>(type: "int", nullable: false),
                    SET = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTIVITIES", x => x.ACTIVITY_ID);
                    table.ForeignKey(
                        name: "FK_ACTIVITIES_EXERCISES_EXERCISE_ID",
                        column: x => x.EXERCISE_ID,
                        principalTable: "EXERCISES",
                        principalColumn: "EXERCISE_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WORKOUT_HAS_EXERCISES_JT",
                columns: table => new
                {
                    WORKOUT_ID = table.Column<int>(type: "int", nullable: false),
                    EXERCISE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKOUT_HAS_EXERCISES_JT", x => new { x.EXERCISE_ID, x.WORKOUT_ID });
                    table.ForeignKey(
                        name: "FK_WORKOUT_HAS_EXERCISES_JT_EXERCISES_EXERCISE_ID",
                        column: x => x.EXERCISE_ID,
                        principalTable: "EXERCISES",
                        principalColumn: "EXERCISE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WORKOUT_HAS_EXERCISES_JT_WORKOUTS_WORKOUT_ID",
                        column: x => x.WORKOUT_ID,
                        principalTable: "WORKOUTS",
                        principalColumn: "WORKOUT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITIES_EXERCISE_ID",
                table: "ACTIVITIES",
                column: "EXERCISE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EXERCISES_USER_ID",
                table: "EXERCISES",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_EMAIL",
                table: "USERS",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WORKOUT_HAS_EXERCISES_JT_WORKOUT_ID",
                table: "WORKOUT_HAS_EXERCISES_JT",
                column: "WORKOUT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACTIVITIES");

            migrationBuilder.DropTable(
                name: "WORKOUT_HAS_EXERCISES_JT");

            migrationBuilder.DropTable(
                name: "EXERCISES");

            migrationBuilder.DropTable(
                name: "WORKOUTS");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
