namespace Model.Entities.Library;

public class WorkoutLibrary
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("WORKOUT_LIBRARY_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")] 
    public string Name { get; set; }
    
    [DataType(DataType.Text)]
    [Column("DESCRIPTION")]
    public string? Description { get; set; }
}