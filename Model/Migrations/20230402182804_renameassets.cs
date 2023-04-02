using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class renameassets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EXERCISE_HAS_MUSCLE_LIBRARIES_JT_EXERCISES_EXERCISE_ID",
                table: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT");

            migrationBuilder.DropForeignKey(
                name: "FK_EXERCISE_HAS_MUSCLE_LIBRARIES_JT_MUSCLE_LIBRARIES_MUSCLE_LIB~",
                table: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT");

            migrationBuilder.DropForeignKey(
                name: "FK_EXERCISES_MACHINE_LIBRARIES_MACHINE_LIBRARY_ID",
                table: "EXERCISES");

            migrationBuilder.DropTable(
                name: "EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT");

            migrationBuilder.DropTable(
                name: "WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT");

            migrationBuilder.DropTable(
                name: "MUSCLE_LIBRARIES");

            migrationBuilder.DropTable(
                name: "EXERCISE_LIBRARIES");

            migrationBuilder.DropTable(
                name: "WORKOUT_LIBRARIES");

            migrationBuilder.DropTable(
                name: "MACHINE_LIBRARIES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EXERCISE_HAS_MUSCLE_LIBRARIES_JT",
                table: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT");

            migrationBuilder.RenameTable(
                name: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT",
                newName: "EXERCISE_HAS_MUSCLE_ASSETS_JT");

            migrationBuilder.RenameColumn(
                name: "MACHINE_LIBRARY_ID",
                table: "EXERCISES",
                newName: "MACHINE_ASSET_ID");

            migrationBuilder.RenameIndex(
                name: "IX_EXERCISES_MACHINE_LIBRARY_ID",
                table: "EXERCISES",
                newName: "IX_EXERCISES_MACHINE_ASSET_ID");

            migrationBuilder.RenameColumn(
                name: "MUSCLE_LIBRARY_ID",
                table: "EXERCISE_HAS_MUSCLE_ASSETS_JT",
                newName: "MUSCLE_ASSET_ID");

            migrationBuilder.RenameIndex(
                name: "IX_EXERCISE_HAS_MUSCLE_LIBRARIES_JT_MUSCLE_LIBRARY_ID",
                table: "EXERCISE_HAS_MUSCLE_ASSETS_JT",
                newName: "IX_EXERCISE_HAS_MUSCLE_ASSETS_JT_MUSCLE_ASSET_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EXERCISE_HAS_MUSCLE_ASSETS_JT",
                table: "EXERCISE_HAS_MUSCLE_ASSETS_JT",
                columns: new[] { "EXERCISE_ID", "MUSCLE_ASSET_ID" });

            migrationBuilder.CreateTable(
                name: "MACHINE_ASSETS",
                columns: table => new
                {
                    MACHINEASSETID = table.Column<int>(name: "MACHINE_ASSET_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MACHINE_ASSETS", x => x.MACHINEASSETID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MUSCLE_ASSETS",
                columns: table => new
                {
                    MUSCLEASSETID = table.Column<int>(name: "MUSCLE_ASSET_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUSCLE_ASSETS", x => x.MUSCLEASSETID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WORKOUT_ASSETS",
                columns: table => new
                {
                    WORKOUTASSETID = table.Column<int>(name: "WORKOUT_ASSET_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKOUT_ASSETS", x => x.WORKOUTASSETID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EXERCISE_ASSETS",
                columns: table => new
                {
                    EXERCISEASSETID = table.Column<int>(name: "EXERCISE_ASSET_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MACHINEASSETID = table.Column<int>(name: "MACHINE_ASSET_ID", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXERCISE_ASSETS", x => x.EXERCISEASSETID);
                    table.ForeignKey(
                        name: "FK_EXERCISE_ASSETS_MACHINE_ASSETS_MACHINE_ASSET_ID",
                        column: x => x.MACHINEASSETID,
                        principalTable: "MACHINE_ASSETS",
                        principalColumn: "MACHINE_ASSET_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EXERCISE_ASSET_HAS_MUSCLE_ASSETS_JT",
                columns: table => new
                {
                    EXERCISEASSETID = table.Column<int>(name: "EXERCISE_ASSET_ID", type: "int", nullable: false),
                    MUSCLEASSETID = table.Column<int>(name: "MUSCLE_ASSET_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXERCISE_ASSET_HAS_MUSCLE_ASSETS_JT", x => new { x.EXERCISEASSETID, x.MUSCLEASSETID });
                    table.ForeignKey(
                        name: "FK_EXERCISE_ASSET_HAS_MUSCLE_ASSETS_JT_EXERCISE_ASSETS_EXERCISE~",
                        column: x => x.EXERCISEASSETID,
                        principalTable: "EXERCISE_ASSETS",
                        principalColumn: "EXERCISE_ASSET_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EXERCISE_ASSET_HAS_MUSCLE_ASSETS_JT_MUSCLE_ASSETS_MUSCLE_ASS~",
                        column: x => x.MUSCLEASSETID,
                        principalTable: "MUSCLE_ASSETS",
                        principalColumn: "MUSCLE_ASSET_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WORKOUT_ASSET_HAS_EXERCISE_ASSETS_JT",
                columns: table => new
                {
                    EXERCISEASSETID = table.Column<int>(name: "EXERCISE_ASSET_ID", type: "int", nullable: false),
                    WORKOUTASSETID = table.Column<int>(name: "WORKOUT_ASSET_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKOUT_ASSET_HAS_EXERCISE_ASSETS_JT", x => new { x.WORKOUTASSETID, x.EXERCISEASSETID });
                    table.ForeignKey(
                        name: "FK_WORKOUT_ASSET_HAS_EXERCISE_ASSETS_JT_EXERCISE_ASSETS_EXERCIS~",
                        column: x => x.EXERCISEASSETID,
                        principalTable: "EXERCISE_ASSETS",
                        principalColumn: "EXERCISE_ASSET_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WORKOUT_ASSET_HAS_EXERCISE_ASSETS_JT_WORKOUT_ASSETS_WORKOUT_~",
                        column: x => x.WORKOUTASSETID,
                        principalTable: "WORKOUT_ASSETS",
                        principalColumn: "WORKOUT_ASSET_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EXERCISE_ASSET_HAS_MUSCLE_ASSETS_JT_MUSCLE_ASSET_ID",
                table: "EXERCISE_ASSET_HAS_MUSCLE_ASSETS_JT",
                column: "MUSCLE_ASSET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EXERCISE_ASSETS_MACHINE_ASSET_ID",
                table: "EXERCISE_ASSETS",
                column: "MACHINE_ASSET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WORKOUT_ASSET_HAS_EXERCISE_ASSETS_JT_EXERCISE_ASSET_ID",
                table: "WORKOUT_ASSET_HAS_EXERCISE_ASSETS_JT",
                column: "EXERCISE_ASSET_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EXERCISE_HAS_MUSCLE_ASSETS_JT_EXERCISES_EXERCISE_ID",
                table: "EXERCISE_HAS_MUSCLE_ASSETS_JT",
                column: "EXERCISE_ID",
                principalTable: "EXERCISES",
                principalColumn: "EXERCISE_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EXERCISE_HAS_MUSCLE_ASSETS_JT_MUSCLE_ASSETS_MUSCLE_ASSET_ID",
                table: "EXERCISE_HAS_MUSCLE_ASSETS_JT",
                column: "MUSCLE_ASSET_ID",
                principalTable: "MUSCLE_ASSETS",
                principalColumn: "MUSCLE_ASSET_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EXERCISES_MACHINE_ASSETS_MACHINE_ASSET_ID",
                table: "EXERCISES",
                column: "MACHINE_ASSET_ID",
                principalTable: "MACHINE_ASSETS",
                principalColumn: "MACHINE_ASSET_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EXERCISE_HAS_MUSCLE_ASSETS_JT_EXERCISES_EXERCISE_ID",
                table: "EXERCISE_HAS_MUSCLE_ASSETS_JT");

            migrationBuilder.DropForeignKey(
                name: "FK_EXERCISE_HAS_MUSCLE_ASSETS_JT_MUSCLE_ASSETS_MUSCLE_ASSET_ID",
                table: "EXERCISE_HAS_MUSCLE_ASSETS_JT");

            migrationBuilder.DropForeignKey(
                name: "FK_EXERCISES_MACHINE_ASSETS_MACHINE_ASSET_ID",
                table: "EXERCISES");

            migrationBuilder.DropTable(
                name: "EXERCISE_ASSET_HAS_MUSCLE_ASSETS_JT");

            migrationBuilder.DropTable(
                name: "WORKOUT_ASSET_HAS_EXERCISE_ASSETS_JT");

            migrationBuilder.DropTable(
                name: "MUSCLE_ASSETS");

            migrationBuilder.DropTable(
                name: "EXERCISE_ASSETS");

            migrationBuilder.DropTable(
                name: "WORKOUT_ASSETS");

            migrationBuilder.DropTable(
                name: "MACHINE_ASSETS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EXERCISE_HAS_MUSCLE_ASSETS_JT",
                table: "EXERCISE_HAS_MUSCLE_ASSETS_JT");

            migrationBuilder.RenameTable(
                name: "EXERCISE_HAS_MUSCLE_ASSETS_JT",
                newName: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT");

            migrationBuilder.RenameColumn(
                name: "MACHINE_ASSET_ID",
                table: "EXERCISES",
                newName: "MACHINE_LIBRARY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_EXERCISES_MACHINE_ASSET_ID",
                table: "EXERCISES",
                newName: "IX_EXERCISES_MACHINE_LIBRARY_ID");

            migrationBuilder.RenameColumn(
                name: "MUSCLE_ASSET_ID",
                table: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT",
                newName: "MUSCLE_LIBRARY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_EXERCISE_HAS_MUSCLE_ASSETS_JT_MUSCLE_ASSET_ID",
                table: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT",
                newName: "IX_EXERCISE_HAS_MUSCLE_LIBRARIES_JT_MUSCLE_LIBRARY_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EXERCISE_HAS_MUSCLE_LIBRARIES_JT",
                table: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT",
                columns: new[] { "EXERCISE_ID", "MUSCLE_LIBRARY_ID" });

            migrationBuilder.CreateTable(
                name: "MACHINE_LIBRARIES",
                columns: table => new
                {
                    MACHINELIBRARYID = table.Column<int>(name: "MACHINE_LIBRARY_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MACHINE_LIBRARIES", x => x.MACHINELIBRARYID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MUSCLE_LIBRARIES",
                columns: table => new
                {
                    MUSCLELIBRARYID = table.Column<int>(name: "MUSCLE_LIBRARY_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUSCLE_LIBRARIES", x => x.MUSCLELIBRARYID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WORKOUT_LIBRARIES",
                columns: table => new
                {
                    WORKOUTLIBRARYID = table.Column<int>(name: "WORKOUT_LIBRARY_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKOUT_LIBRARIES", x => x.WORKOUTLIBRARYID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EXERCISE_LIBRARIES",
                columns: table => new
                {
                    EXERCISELIBRARYID = table.Column<int>(name: "EXERCISE_LIBRARY_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MACHINELIBRARYID = table.Column<int>(name: "MACHINE_LIBRARY_ID", type: "int", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXERCISE_LIBRARIES", x => x.EXERCISELIBRARYID);
                    table.ForeignKey(
                        name: "FK_EXERCISE_LIBRARIES_MACHINE_LIBRARIES_MACHINE_LIBRARY_ID",
                        column: x => x.MACHINELIBRARYID,
                        principalTable: "MACHINE_LIBRARIES",
                        principalColumn: "MACHINE_LIBRARY_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT",
                columns: table => new
                {
                    EXERCISELIBRARYID = table.Column<int>(name: "EXERCISE_LIBRARY_ID", type: "int", nullable: false),
                    MUSCLELIBRARYID = table.Column<int>(name: "MUSCLE_LIBRARY_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT", x => new { x.EXERCISELIBRARYID, x.MUSCLELIBRARYID });
                    table.ForeignKey(
                        name: "FK_EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT_EXERCISE_LIBRARIES_~",
                        column: x => x.EXERCISELIBRARYID,
                        principalTable: "EXERCISE_LIBRARIES",
                        principalColumn: "EXERCISE_LIBRARY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT_MUSCLE_LIBRARIES_MU~",
                        column: x => x.MUSCLELIBRARYID,
                        principalTable: "MUSCLE_LIBRARIES",
                        principalColumn: "MUSCLE_LIBRARY_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT",
                columns: table => new
                {
                    WORKOUTLIBRARYID = table.Column<int>(name: "WORKOUT_LIBRARY_ID", type: "int", nullable: false),
                    EXERCISELIBRARYID = table.Column<int>(name: "EXERCISE_LIBRARY_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT", x => new { x.WORKOUTLIBRARYID, x.EXERCISELIBRARYID });
                    table.ForeignKey(
                        name: "FK_WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT_EXERCISE_LIBRARIES~",
                        column: x => x.EXERCISELIBRARYID,
                        principalTable: "EXERCISE_LIBRARIES",
                        principalColumn: "EXERCISE_LIBRARY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT_WORKOUT_LIBRARIES_~",
                        column: x => x.WORKOUTLIBRARYID,
                        principalTable: "WORKOUT_LIBRARIES",
                        principalColumn: "WORKOUT_LIBRARY_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EXERCISE_LIBRARIES_MACHINE_LIBRARY_ID",
                table: "EXERCISE_LIBRARIES",
                column: "MACHINE_LIBRARY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT_MUSCLE_LIBRARY_ID",
                table: "EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT",
                column: "MUSCLE_LIBRARY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT_EXERCISE_LIBRARY_ID",
                table: "WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT",
                column: "EXERCISE_LIBRARY_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EXERCISE_HAS_MUSCLE_LIBRARIES_JT_EXERCISES_EXERCISE_ID",
                table: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT",
                column: "EXERCISE_ID",
                principalTable: "EXERCISES",
                principalColumn: "EXERCISE_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EXERCISE_HAS_MUSCLE_LIBRARIES_JT_MUSCLE_LIBRARIES_MUSCLE_LIB~",
                table: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT",
                column: "MUSCLE_LIBRARY_ID",
                principalTable: "MUSCLE_LIBRARIES",
                principalColumn: "MUSCLE_LIBRARY_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EXERCISES_MACHINE_LIBRARIES_MACHINE_LIBRARY_ID",
                table: "EXERCISES",
                column: "MACHINE_LIBRARY_ID",
                principalTable: "MACHINE_LIBRARIES",
                principalColumn: "MACHINE_LIBRARY_ID");
        }
    }
}
