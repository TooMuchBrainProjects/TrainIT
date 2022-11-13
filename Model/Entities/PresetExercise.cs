using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("PRESET_HAS_EXERCISES_JT")]
public class PresetExercise
{
    [Column("PRESET_ID")] 
    public int PresetId { get; set; }

    public Preset Preset { get; set; }
    
    [Column("EXERCISE_ID")] 
    public int ExerciseId { get; set; }

    public Exercise Exercise { get; set; }
}