namespace Model.Entities.Library;

public class WorkoutLibraryExerciseLibrary
{
    [Column("EXERCISE_LIBRARY_ID")] 
    public int ExerciseLibraryId { get; set; }
    public ExerciseLibrary ExerciseLibrary { get; set; }
    
    [Column("WORKOUT_LIBRARY_ID")] 
    public int WorkoutLibraryId { get; set; }
    public WorkoutLibrary WorkoutLibrary { get; set; }
}