using Model.Entities.Library;

namespace Model.Entities;

public class ExerciseMuscleLibrary
{
    [Column("EXERCISE_ID")] 
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
    
    [Column("MUSCLE_LIBRARY_ID")] 
    public int MuscleLibraryId { get; set; }
    public MuscleLibrary MuscleLibrary { get; set; }
}