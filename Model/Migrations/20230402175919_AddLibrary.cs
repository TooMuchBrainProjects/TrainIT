using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class AddLibrary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MACHINE",
                table: "EXERCISES");

            migrationBuilder.AlterColumn<string>(
                name: "USERNAME",
                table: "USERS",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)",
                oldMaxLength: 32)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "USERS",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "MACHINE_LIBRARY_ID",
                table: "EXERCISES",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MachineLibraries",
                columns: table => new
                {
                    MACHINELIBRARYID = table.Column<int>(name: "MACHINE_LIBRARY_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineLibraries", x => x.MACHINELIBRARYID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MuscleLibraries",
                columns: table => new
                {
                    MUSCLELIBRARYID = table.Column<int>(name: "MUSCLE_LIBRARY_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleLibraries", x => x.MUSCLELIBRARYID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkoutLibraries",
                columns: table => new
                {
                    WORKOUTLIBRARYID = table.Column<int>(name: "WORKOUT_LIBRARY_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutLibraries", x => x.WORKOUTLIBRARYID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExerciseLibraries",
                columns: table => new
                {
                    EXERCISELIBRARYID = table.Column<int>(name: "EXERCISE_LIBRARY_ID", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MACHINELIBRARYID = table.Column<int>(name: "MACHINE_LIBRARY_ID", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseLibraries", x => x.EXERCISELIBRARYID);
                    table.ForeignKey(
                        name: "FK_ExerciseLibraries_MachineLibraries_MACHINE_LIBRARY_ID",
                        column: x => x.MACHINELIBRARYID,
                        principalTable: "MachineLibraries",
                        principalColumn: "MACHINE_LIBRARY_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExerciseMuscleLibraries",
                columns: table => new
                {
                    EXERCISEID = table.Column<int>(name: "EXERCISE_ID", type: "int", nullable: false),
                    MUSCLELIBRARYID = table.Column<int>(name: "MUSCLE_LIBRARY_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscleLibraries", x => new { x.EXERCISEID, x.MUSCLELIBRARYID });
                    table.ForeignKey(
                        name: "FK_ExerciseMuscleLibraries_EXERCISES_EXERCISE_ID",
                        column: x => x.EXERCISEID,
                        principalTable: "EXERCISES",
                        principalColumn: "EXERCISE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscleLibraries_MuscleLibraries_MUSCLE_LIBRARY_ID",
                        column: x => x.MUSCLELIBRARYID,
                        principalTable: "MuscleLibraries",
                        principalColumn: "MUSCLE_LIBRARY_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExerciseLibraryMuscleLibraries",
                columns: table => new
                {
                    EXERCISELIBRARYID = table.Column<int>(name: "EXERCISE_LIBRARY_ID", type: "int", nullable: false),
                    MUSCLESLIBRARYID = table.Column<int>(name: "MUSCLES_LIBRARY_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseLibraryMuscleLibraries", x => new { x.EXERCISELIBRARYID, x.MUSCLESLIBRARYID });
                    table.ForeignKey(
                        name: "FK_ExerciseLibraryMuscleLibraries_ExerciseLibraries_EXERCISE_LI~",
                        column: x => x.EXERCISELIBRARYID,
                        principalTable: "ExerciseLibraries",
                        principalColumn: "EXERCISE_LIBRARY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseLibraryMuscleLibraries_MuscleLibraries_MUSCLES_LIBRA~",
                        column: x => x.MUSCLESLIBRARYID,
                        principalTable: "MuscleLibraries",
                        principalColumn: "MUSCLE_LIBRARY_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkoutLibraryExerciseLibraries",
                columns: table => new
                {
                    EXERCISELIBRARYID = table.Column<int>(name: "EXERCISE_LIBRARY_ID", type: "int", nullable: false),
                    WORKOUTLIBRARYID = table.Column<int>(name: "WORKOUT_LIBRARY_ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutLibraryExerciseLibraries", x => new { x.WORKOUTLIBRARYID, x.EXERCISELIBRARYID });
                    table.ForeignKey(
                        name: "FK_WorkoutLibraryExerciseLibraries_ExerciseLibraries_EXERCISE_L~",
                        column: x => x.EXERCISELIBRARYID,
                        principalTable: "ExerciseLibraries",
                        principalColumn: "EXERCISE_LIBRARY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutLibraryExerciseLibraries_WorkoutLibraries_WORKOUT_LIB~",
                        column: x => x.WORKOUTLIBRARYID,
                        principalTable: "WorkoutLibraries",
                        principalColumn: "WORKOUT_LIBRARY_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EXERCISES_MACHINE_LIBRARY_ID",
                table: "EXERCISES",
                column: "MACHINE_LIBRARY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseLibraries_MACHINE_LIBRARY_ID",
                table: "ExerciseLibraries",
                column: "MACHINE_LIBRARY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseLibraryMuscleLibraries_MUSCLES_LIBRARY_ID",
                table: "ExerciseLibraryMuscleLibraries",
                column: "MUSCLES_LIBRARY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscleLibraries_MUSCLE_LIBRARY_ID",
                table: "ExerciseMuscleLibraries",
                column: "MUSCLE_LIBRARY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLibraryExerciseLibraries_EXERCISE_LIBRARY_ID",
                table: "WorkoutLibraryExerciseLibraries",
                column: "EXERCISE_LIBRARY_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EXERCISES_MachineLibraries_MACHINE_LIBRARY_ID",
                table: "EXERCISES",
                column: "MACHINE_LIBRARY_ID",
                principalTable: "MachineLibraries",
                principalColumn: "MACHINE_LIBRARY_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EXERCISES_MachineLibraries_MACHINE_LIBRARY_ID",
                table: "EXERCISES");

            migrationBuilder.DropTable(
                name: "ExerciseLibraryMuscleLibraries");

            migrationBuilder.DropTable(
                name: "ExerciseMuscleLibraries");

            migrationBuilder.DropTable(
                name: "WorkoutLibraryExerciseLibraries");

            migrationBuilder.DropTable(
                name: "MuscleLibraries");

            migrationBuilder.DropTable(
                name: "ExerciseLibraries");

            migrationBuilder.DropTable(
                name: "WorkoutLibraries");

            migrationBuilder.DropTable(
                name: "MachineLibraries");

            migrationBuilder.DropIndex(
                name: "IX_EXERCISES_MACHINE_LIBRARY_ID",
                table: "EXERCISES");

            migrationBuilder.DropColumn(
                name: "MACHINE_LIBRARY_ID",
                table: "EXERCISES");

            migrationBuilder.AlterColumn<string>(
                name: "USERNAME",
                table: "USERS",
                type: "varchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "USERS",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MACHINE",
                table: "EXERCISES",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
