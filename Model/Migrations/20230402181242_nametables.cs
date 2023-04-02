using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class nametables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseLibraries_MachineLibraries_MACHINE_LIBRARY_ID",
                table: "ExerciseLibraries");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseLibraryMuscleLibraries_ExerciseLibraries_EXERCISE_LI~",
                table: "ExerciseLibraryMuscleLibraries");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseLibraryMuscleLibraries_MuscleLibraries_MUSCLES_LIBRA~",
                table: "ExerciseLibraryMuscleLibraries");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseMuscleLibraries_EXERCISES_EXERCISE_ID",
                table: "ExerciseMuscleLibraries");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseMuscleLibraries_MuscleLibraries_MUSCLE_LIBRARY_ID",
                table: "ExerciseMuscleLibraries");

            migrationBuilder.DropForeignKey(
                name: "FK_EXERCISES_MachineLibraries_MACHINE_LIBRARY_ID",
                table: "EXERCISES");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutLibraryExerciseLibraries_ExerciseLibraries_EXERCISE_L~",
                table: "WorkoutLibraryExerciseLibraries");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutLibraryExerciseLibraries_WorkoutLibraries_WORKOUT_LIB~",
                table: "WorkoutLibraryExerciseLibraries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutLibraryExerciseLibraries",
                table: "WorkoutLibraryExerciseLibraries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutLibraries",
                table: "WorkoutLibraries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MuscleLibraries",
                table: "MuscleLibraries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MachineLibraries",
                table: "MachineLibraries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseMuscleLibraries",
                table: "ExerciseMuscleLibraries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseLibraryMuscleLibraries",
                table: "ExerciseLibraryMuscleLibraries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseLibraries",
                table: "ExerciseLibraries");

            migrationBuilder.RenameTable(
                name: "WorkoutLibraryExerciseLibraries",
                newName: "WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT");

            migrationBuilder.RenameTable(
                name: "WorkoutLibraries",
                newName: "WORKOUT_LIBRARIES");

            migrationBuilder.RenameTable(
                name: "MuscleLibraries",
                newName: "MUSCLE_LIBRARIES");

            migrationBuilder.RenameTable(
                name: "MachineLibraries",
                newName: "MACHINE_LIBRARIES");

            migrationBuilder.RenameTable(
                name: "ExerciseMuscleLibraries",
                newName: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT");

            migrationBuilder.RenameTable(
                name: "ExerciseLibraryMuscleLibraries",
                newName: "EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT");

            migrationBuilder.RenameTable(
                name: "ExerciseLibraries",
                newName: "EXERCISE_LIBRARIES");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutLibraryExerciseLibraries_EXERCISE_LIBRARY_ID",
                table: "WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT",
                newName: "IX_WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT_EXERCISE_LIBRARY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseMuscleLibraries_MUSCLE_LIBRARY_ID",
                table: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT",
                newName: "IX_EXERCISE_HAS_MUSCLE_LIBRARIES_JT_MUSCLE_LIBRARY_ID");

            migrationBuilder.RenameColumn(
                name: "MUSCLES_LIBRARY_ID",
                table: "EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT",
                newName: "MUSCLE_LIBRARY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseLibraryMuscleLibraries_MUSCLES_LIBRARY_ID",
                table: "EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT",
                newName: "IX_EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT_MUSCLE_LIBRARY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseLibraries_MACHINE_LIBRARY_ID",
                table: "EXERCISE_LIBRARIES",
                newName: "IX_EXERCISE_LIBRARIES_MACHINE_LIBRARY_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT",
                table: "WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT",
                columns: new[] { "WORKOUT_LIBRARY_ID", "EXERCISE_LIBRARY_ID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_WORKOUT_LIBRARIES",
                table: "WORKOUT_LIBRARIES",
                column: "WORKOUT_LIBRARY_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MUSCLE_LIBRARIES",
                table: "MUSCLE_LIBRARIES",
                column: "MUSCLE_LIBRARY_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MACHINE_LIBRARIES",
                table: "MACHINE_LIBRARIES",
                column: "MACHINE_LIBRARY_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EXERCISE_HAS_MUSCLE_LIBRARIES_JT",
                table: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT",
                columns: new[] { "EXERCISE_ID", "MUSCLE_LIBRARY_ID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT",
                table: "EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT",
                columns: new[] { "EXERCISE_LIBRARY_ID", "MUSCLE_LIBRARY_ID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EXERCISE_LIBRARIES",
                table: "EXERCISE_LIBRARIES",
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
                name: "FK_EXERCISE_LIBRARIES_MACHINE_LIBRARIES_MACHINE_LIBRARY_ID",
                table: "EXERCISE_LIBRARIES",
                column: "MACHINE_LIBRARY_ID",
                principalTable: "MACHINE_LIBRARIES",
                principalColumn: "MACHINE_LIBRARY_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT_EXERCISE_LIBRARIES_~",
                table: "EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT",
                column: "EXERCISE_LIBRARY_ID",
                principalTable: "EXERCISE_LIBRARIES",
                principalColumn: "EXERCISE_LIBRARY_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT_MUSCLE_LIBRARIES_MU~",
                table: "EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT",
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

            migrationBuilder.AddForeignKey(
                name: "FK_WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT_EXERCISE_LIBRARIES~",
                table: "WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT",
                column: "EXERCISE_LIBRARY_ID",
                principalTable: "EXERCISE_LIBRARIES",
                principalColumn: "EXERCISE_LIBRARY_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT_WORKOUT_LIBRARIES_~",
                table: "WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT",
                column: "WORKOUT_LIBRARY_ID",
                principalTable: "WORKOUT_LIBRARIES",
                principalColumn: "WORKOUT_LIBRARY_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EXERCISE_HAS_MUSCLE_LIBRARIES_JT_EXERCISES_EXERCISE_ID",
                table: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT");

            migrationBuilder.DropForeignKey(
                name: "FK_EXERCISE_HAS_MUSCLE_LIBRARIES_JT_MUSCLE_LIBRARIES_MUSCLE_LIB~",
                table: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT");

            migrationBuilder.DropForeignKey(
                name: "FK_EXERCISE_LIBRARIES_MACHINE_LIBRARIES_MACHINE_LIBRARY_ID",
                table: "EXERCISE_LIBRARIES");

            migrationBuilder.DropForeignKey(
                name: "FK_EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT_EXERCISE_LIBRARIES_~",
                table: "EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT");

            migrationBuilder.DropForeignKey(
                name: "FK_EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT_MUSCLE_LIBRARIES_MU~",
                table: "EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT");

            migrationBuilder.DropForeignKey(
                name: "FK_EXERCISES_MACHINE_LIBRARIES_MACHINE_LIBRARY_ID",
                table: "EXERCISES");

            migrationBuilder.DropForeignKey(
                name: "FK_WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT_EXERCISE_LIBRARIES~",
                table: "WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT");

            migrationBuilder.DropForeignKey(
                name: "FK_WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT_WORKOUT_LIBRARIES_~",
                table: "WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT",
                table: "WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WORKOUT_LIBRARIES",
                table: "WORKOUT_LIBRARIES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MUSCLE_LIBRARIES",
                table: "MUSCLE_LIBRARIES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MACHINE_LIBRARIES",
                table: "MACHINE_LIBRARIES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT",
                table: "EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EXERCISE_LIBRARIES",
                table: "EXERCISE_LIBRARIES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EXERCISE_HAS_MUSCLE_LIBRARIES_JT",
                table: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT");

            migrationBuilder.RenameTable(
                name: "WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT",
                newName: "WorkoutLibraryExerciseLibraries");

            migrationBuilder.RenameTable(
                name: "WORKOUT_LIBRARIES",
                newName: "WorkoutLibraries");

            migrationBuilder.RenameTable(
                name: "MUSCLE_LIBRARIES",
                newName: "MuscleLibraries");

            migrationBuilder.RenameTable(
                name: "MACHINE_LIBRARIES",
                newName: "MachineLibraries");

            migrationBuilder.RenameTable(
                name: "EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT",
                newName: "ExerciseLibraryMuscleLibraries");

            migrationBuilder.RenameTable(
                name: "EXERCISE_LIBRARIES",
                newName: "ExerciseLibraries");

            migrationBuilder.RenameTable(
                name: "EXERCISE_HAS_MUSCLE_LIBRARIES_JT",
                newName: "ExerciseMuscleLibraries");

            migrationBuilder.RenameIndex(
                name: "IX_WORKOUT_LIBRARY_HAS_EXERCISE_LIBRARIES_JT_EXERCISE_LIBRARY_ID",
                table: "WorkoutLibraryExerciseLibraries",
                newName: "IX_WorkoutLibraryExerciseLibraries_EXERCISE_LIBRARY_ID");

            migrationBuilder.RenameColumn(
                name: "MUSCLE_LIBRARY_ID",
                table: "ExerciseLibraryMuscleLibraries",
                newName: "MUSCLES_LIBRARY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT_MUSCLE_LIBRARY_ID",
                table: "ExerciseLibraryMuscleLibraries",
                newName: "IX_ExerciseLibraryMuscleLibraries_MUSCLES_LIBRARY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_EXERCISE_LIBRARIES_MACHINE_LIBRARY_ID",
                table: "ExerciseLibraries",
                newName: "IX_ExerciseLibraries_MACHINE_LIBRARY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_EXERCISE_HAS_MUSCLE_LIBRARIES_JT_MUSCLE_LIBRARY_ID",
                table: "ExerciseMuscleLibraries",
                newName: "IX_ExerciseMuscleLibraries_MUSCLE_LIBRARY_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutLibraryExerciseLibraries",
                table: "WorkoutLibraryExerciseLibraries",
                columns: new[] { "WORKOUT_LIBRARY_ID", "EXERCISE_LIBRARY_ID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutLibraries",
                table: "WorkoutLibraries",
                column: "WORKOUT_LIBRARY_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MuscleLibraries",
                table: "MuscleLibraries",
                column: "MUSCLE_LIBRARY_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MachineLibraries",
                table: "MachineLibraries",
                column: "MACHINE_LIBRARY_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseLibraryMuscleLibraries",
                table: "ExerciseLibraryMuscleLibraries",
                columns: new[] { "EXERCISE_LIBRARY_ID", "MUSCLES_LIBRARY_ID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseLibraries",
                table: "ExerciseLibraries",
                column: "EXERCISE_LIBRARY_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseMuscleLibraries",
                table: "ExerciseMuscleLibraries",
                columns: new[] { "EXERCISE_ID", "MUSCLE_LIBRARY_ID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseLibraries_MachineLibraries_MACHINE_LIBRARY_ID",
                table: "ExerciseLibraries",
                column: "MACHINE_LIBRARY_ID",
                principalTable: "MachineLibraries",
                principalColumn: "MACHINE_LIBRARY_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseLibraryMuscleLibraries_ExerciseLibraries_EXERCISE_LI~",
                table: "ExerciseLibraryMuscleLibraries",
                column: "EXERCISE_LIBRARY_ID",
                principalTable: "ExerciseLibraries",
                principalColumn: "EXERCISE_LIBRARY_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseLibraryMuscleLibraries_MuscleLibraries_MUSCLES_LIBRA~",
                table: "ExerciseLibraryMuscleLibraries",
                column: "MUSCLES_LIBRARY_ID",
                principalTable: "MuscleLibraries",
                principalColumn: "MUSCLE_LIBRARY_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseMuscleLibraries_EXERCISES_EXERCISE_ID",
                table: "ExerciseMuscleLibraries",
                column: "EXERCISE_ID",
                principalTable: "EXERCISES",
                principalColumn: "EXERCISE_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseMuscleLibraries_MuscleLibraries_MUSCLE_LIBRARY_ID",
                table: "ExerciseMuscleLibraries",
                column: "MUSCLE_LIBRARY_ID",
                principalTable: "MuscleLibraries",
                principalColumn: "MUSCLE_LIBRARY_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EXERCISES_MachineLibraries_MACHINE_LIBRARY_ID",
                table: "EXERCISES",
                column: "MACHINE_LIBRARY_ID",
                principalTable: "MachineLibraries",
                principalColumn: "MACHINE_LIBRARY_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutLibraryExerciseLibraries_ExerciseLibraries_EXERCISE_L~",
                table: "WorkoutLibraryExerciseLibraries",
                column: "EXERCISE_LIBRARY_ID",
                principalTable: "ExerciseLibraries",
                principalColumn: "EXERCISE_LIBRARY_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutLibraryExerciseLibraries_WorkoutLibraries_WORKOUT_LIB~",
                table: "WorkoutLibraryExerciseLibraries",
                column: "WORKOUT_LIBRARY_ID",
                principalTable: "WorkoutLibraries",
                principalColumn: "WORKOUT_LIBRARY_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
