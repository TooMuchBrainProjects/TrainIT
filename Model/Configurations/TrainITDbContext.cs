using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Configurations;

public class TrainITDbContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<SubExercise> SubExercises { get; set; }
    public DbSet<Preset> Presets { get; set; }
    public DbSet<PresetExercise> PresetExercises { get; set; }
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
        
        modelBuilder.Entity<PresetExercise>()
            .HasKey(d => new { d.ExerciseId, d.PresetId });
        modelBuilder.Entity<PresetExercise>()
            .HasOne(d => d.Exercise)
            .WithMany()
            .HasForeignKey(d => d.ExerciseId);
        modelBuilder.Entity<PresetExercise>()
            .HasOne(d => d.Preset)
            .WithMany()
            .HasForeignKey(d => d.PresetId);
        
        modelBuilder.Entity<SubExercise>()
            .HasOne(d => d.Exercise)
            .WithMany()
            .HasForeignKey(d => d.ExerciseId);
    }
}