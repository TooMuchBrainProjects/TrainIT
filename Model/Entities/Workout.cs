using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("WORKOUTS")]
public class Workout
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("WORKOUT_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")] 
    public string Name { get; set; }
}