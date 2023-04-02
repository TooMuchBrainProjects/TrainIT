namespace Model.Entities.Library;

[Table("EXERCISE_LIBRARY_HAS_MUSCLE_LIBRARIES_JT")]
public class ExerciseLibraryMuscleLibrary
{
    [Column("EXERCISE_LIBRARY_ID")] 
    public int ExerciseLibraryId { get; set; }
    public ExerciseLibrary ExerciseLibrary { get; set; }
    
    [Column("MUSCLE_LIBRARY_ID")] 
    public int MuscleLibraryId { get; set; }
    public MuscleLibrary MuscleLibrary { get; set; }
}