using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Model.Entities;

[Table("DATE_HAS_EXERCISES_JT")]
public class ExerciseDate
{
    [Column("DATE")] 
    public DateOnly DateValue { get; set; }

    public Date Date { get; set; }
    
    [Column("EXERCISE")] 
    public int ExerciseId { get; set; }

    public Exercise Exercise { get; set; }
    
    [Required]
    [Column("WEIGHT")]
    public decimal Weight { get; set; }
}