using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Model.Entities;

[Table("ACTIVITIES")]
public class Activity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ACTIVITY_ID")]
    public int Id { get; set; }

    [Required]
    [Column("EXERCISE_ID")] 
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
    
    [Column("DATE")] 
    public DateOnly DateValue { get; set; }

    [Required]
    [Column("WEIGHT")]
    public float Weight { get; set; }
    
    [Required]
    [Column("REPETITION")]
    public int Repetition { get; set; }
    
    [Required]
    [Column("SET")]
    public int Set { get; set; }
}