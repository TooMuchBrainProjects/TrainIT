using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Model.Entities;

[Table("SUB_EXERCISES")]
public class SubExercise
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("SUB_EXERCISE_ID")]
    public int Id { get; set; }

    [Required]
    [Column("EXERCISE_ID")] 
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
    
    [Column("DATE")] 
    public DateOnly DateValue { get; set; }

    [Required]
    [Column("WEIGHT")]
    public decimal Weight { get; set; }
    
    [Required]
    [Column("REPETITION")]
    public int Repetition { get; set; }
    
    [Required]
    [Column("SET")]
    public int Set { get; set; }
}