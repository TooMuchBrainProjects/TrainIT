using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("WORKOUT_HAS_EXERCISES_JT")]
public class WorkoutExercise
{
    [Column("WORKOUT_ID")] 
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; }
    
    
    [Column("EXERCISE_ID")] 
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
}