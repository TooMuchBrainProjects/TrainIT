using Model.Entities;
using Model.Entities.Log;

namespace Model.Configuration;

public class TrainITDbContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleClaim> RoleClaims { get; set; }
    public DbSet<LogEntry> LogEntries { get; set; }
    
    public TrainITDbContext(DbContextOptions<TrainITDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ENUMS
        modelBuilder.Entity<LogEntry>()
            .Property(r => r.FieldType)
            .HasConversion<string>();
        
        // FOREIGN KEYS
        modelBuilder.Entity<Exercise>()
            .HasOne(d => d.User)
            .WithMany()
            .HasForeignKey(d => d.UserId);
        
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

        modelBuilder.Entity<Workout>()
            .HasOne(w => w.User)
            .WithMany()
            .HasForeignKey(d => d.UserId);
        
        modelBuilder.Entity<RoleClaim>()
            .HasOne(rc => rc.Role)
            .WithMany(r => r.RoleClaims)
            .HasForeignKey(rc => rc.RoleId);

        modelBuilder.Entity<RoleClaim>()
            .HasOne(rc => rc.User)
            .WithMany(u => u.RoleClaims)
            .HasForeignKey(rc => rc.UserId);
        
        modelBuilder.Entity<LogEntry>()
            .HasOne(le => le.User)
            .WithMany()
            .HasForeignKey(le => le.UserId);
        
        // UNIQUE
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Role>()
            .HasIndex(r => r.Identifier)
            .IsUnique();
        
        // HAS KEY
        modelBuilder.Entity<RoleClaim>()
            .HasKey(rc => new { rc.UserId, rc.RoleId });
        
        modelBuilder.Entity<WorkoutExercise>()
            .HasKey(d => new { d.ExerciseId, d.WorkoutId });
        
        // OTHER
        // SEEDING
        modelBuilder.Entity<Role>()
            .HasData(new Role { Id = 1, Identifier = "Admin", Description = "Administrator" });
    }
}