namespace Model.Entities.Library;

public class ExerciseLibraryMuscleLibrary
{
    [Column("EXERCISE_LIBRARY_ID")] 
    public int ExerciseLibraryId { get; set; }
    public ExerciseLibrary ExerciseLibrary { get; set; }
    
    [Column("MUSCLES_LIBRARY_ID")] 
    public int MusclesLibraryId { get; set; }
    public MuscleLibrary MuscleLibrary { get; set; }
}