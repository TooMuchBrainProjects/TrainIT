namespace Model.Entities.Library;

[Table("MACHINE_LIBRARIES")]
public class MachineLibrary
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("MACHINE_LIBRARY_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")]
    public string Name { get; set; }
    
    public List<ExerciseLibrary> ExerciseLibraries { get; set; }
}