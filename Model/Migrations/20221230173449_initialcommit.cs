using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class initialcommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    ROLEID = table.Column<int>(name: "ROLE_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IDENTIFIER = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.ROLEID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    USERID = table.Column<int>(name: "USER_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    USERNAME = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PASSWORDHASH = table.Column<string>(name: "PASSWORD_HASH", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.USERID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WORKOUTS",
                columns: table => new
                {
                    WORKOUTID = table.Column<int>(name: "WORKOUT_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKOUTS", x => x.WORKOUTID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EXERCISES",
                columns: table => new
                {
                    EXERCISEID = table.Column<int>(name: "EXERCISE_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MACHINE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USERID = table.Column<int>(name: "USER_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXERCISES", x => x.EXERCISEID);
                    table.ForeignKey(
                        name: "FK_EXERCISES_USERS_USER_ID",
                        column: x => x.USERID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "USER_HAS_ROLES_JT",
                columns: table => new
                {
                    USERID = table.Column<int>(name: "USER_ID", type: "int", nullable: false),
                    ROLEID = table.Column<int>(name: "ROLE_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_HAS_ROLES_JT", x => new { x.USERID, x.ROLEID });
                    table.ForeignKey(
                        name: "FK_USER_HAS_ROLES_JT_ROLES_ROLE_ID",
                        column: x => x.ROLEID,
                        principalTable: "ROLES",
                        principalColumn: "ROLE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_HAS_ROLES_JT_USERS_USER_ID",
                        column: x => x.USERID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ACTIVITIES",
                columns: table => new
                {
                    ACTIVITYID = table.Column<int>(name: "ACTIVITY_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EXERCISEID = table.Column<int>(name: "EXERCISE_ID", type: "int", nullable: false),
                    DATE = table.Column<DateOnly>(type: "date", nullable: false),
                    WEIGHT = table.Column<float>(type: "float", nullable: false),
                    REPETITION = table.Column<int>(type: "int", nullable: false),
                    SET = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACTIVITIES", x => x.ACTIVITYID);
                    table.ForeignKey(
                        name: "FK_ACTIVITIES_EXERCISES_EXERCISE_ID",
                        column: x => x.EXERCISEID,
                        principalTable: "EXERCISES",
                        principalColumn: "EXERCISE_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WORKOUT_HAS_EXERCISES_JT",
                columns: table => new
                {
                    WORKOUTID = table.Column<int>(name: "WORKOUT_ID", type: "int", nullable: false),
                    EXERCISEID = table.Column<int>(name: "EXERCISE_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKOUT_HAS_EXERCISES_JT", x => new { x.EXERCISEID, x.WORKOUTID });
                    table.ForeignKey(
                        name: "FK_WORKOUT_HAS_EXERCISES_JT_EXERCISES_EXERCISE_ID",
                        column: x => x.EXERCISEID,
                        principalTable: "EXERCISES",
                        principalColumn: "EXERCISE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WORKOUT_HAS_EXERCISES_JT_WORKOUTS_WORKOUT_ID",
                        column: x => x.WORKOUTID,
                        principalTable: "WORKOUTS",
                        principalColumn: "WORKOUT_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ROLES",
                columns: new[] { "ROLE_ID", "DESCRIPTION", "IDENTIFIER" },
                values: new object[] { 1, "Administrator", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITIES_EXERCISE_ID",
                table: "ACTIVITIES",
                column: "EXERCISE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EXERCISES_USER_ID",
                table: "EXERCISES",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ROLES_IDENTIFIER",
                table: "ROLES",
                column: "IDENTIFIER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USER_HAS_ROLES_JT_ROLE_ID",
                table: "USER_HAS_ROLES_JT",
                column: "ROLE_ID");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACTIVITIES");

            migrationBuilder.DropTable(
                name: "USER_HAS_ROLES_JT");

            migrationBuilder.DropTable(
                name: "WORKOUT_HAS_EXERCISES_JT");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "EXERCISES");

            migrationBuilder.DropTable(
                name: "WORKOUTS");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
