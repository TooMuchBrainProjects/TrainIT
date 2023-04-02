using Model.Entities.Library;

namespace Model.Entities.per_User;

[Table("EXERCISE_HAS_MUSCLE_LIBRARIES_JT")]
public class ExerciseMuscleLibrary
{
    [Column("EXERCISE_ID")] 
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
    
    [Column("MUSCLE_LIBRARY_ID")] 
    public int MuscleLibraryId { get; set; }
    public MuscleLibrary MuscleLibrary { get; set; }
}