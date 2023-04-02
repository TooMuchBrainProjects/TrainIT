namespace Model.Entities.Library;

[Table("EXERCISE_LIBRARIES")]
public class ExerciseLibrary
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("EXERCISE_LIBRARY_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")]
    public string Name { get; set; }
    
    [DataType(DataType.Text)]
    [Column("DESCRIPTION")]
    public string? Description { get; set; }
    
    [Column("MACHINE_LIBRARY_ID")]
    public int? MachineLibraryId { get; set; }
    public MachineLibrary? MachineLibrary { get; set; }
    
    public List<ExerciseLibraryMuscleLibrary> ExerciseLibraryMuscleLibraries { get; set; }
    
    public List<WorkoutLibraryExerciseLibrary> WorkoutLibraryExerciseLibraries { get; set; }
}