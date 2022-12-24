using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Configurations;

public class TrainITDbContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    public DbSet<User> Users { get; set; }
    
    public TrainITDbContext(DbContextOptions<TrainITDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(d => d.Email)
            .IsUnique(true);
        
        modelBuilder.Entity<Exercise>()
            .HasOne(d => d.User)
            .WithMany()
            .HasForeignKey(d => d.UserId);
        
        modelBuilder.Entity<WorkoutExercise>()
            .HasKey(d => new { d.ExerciseId, d.WorkoutId });
        
        modelBuilder.Entity<WorkoutExercise>()
            .HasOne(d => d.Exercise)
            .WithMany()
            .HasForeignKey(d => d.ExerciseId);
        
        modelBuilder.Entity<WorkoutExercise>()
            .HasOne(d => d.Workout)
            .WithMany()
            .HasForeignKey(d => d.WorkoutId);
        
        modelBuilder.Entity<Activity>()
            .HasOne(d => d.Exercise)
            .WithMany()
            .HasForeignKey(d => d.ExerciseId);
    }
}