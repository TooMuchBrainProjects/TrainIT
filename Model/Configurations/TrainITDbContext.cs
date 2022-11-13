using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Configurations;

public class TrainITDbContext : DbContext
{
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
        modelBuilder.Entity<ExerciseDate>()
            .HasOne(d => d.Date)
            .WithMany()
            .HasForeignKey(d => d.DateValue);
        modelBuilder.Entity<ExerciseDate>()
            .HasOne(d => d.Exercise)
            .WithMany()
            .HasForeignKey(d => d.ExerciseId);
    }
}