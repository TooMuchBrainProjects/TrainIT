namespace Model.Entities.Library;

public class MuscleLibrary
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("MUSCLE_LIBRARY_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")] 
    public string Name { get; set; }
}