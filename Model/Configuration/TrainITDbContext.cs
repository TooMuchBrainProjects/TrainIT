using Model.Entities;

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
        
        // RELATIONSHIPS
        // 1:1
        // 1:N
        // N:M

        modelBuilder.Entity<RoleClaim>()
            .HasOne(rc => rc.Role)
            .WithMany(r => r.RoleClaims)
            .HasForeignKey(rc => rc.RoleId);

        modelBuilder.Entity<RoleClaim>()
            .HasOne(rc => rc.User)
            .WithMany(u => u.RoleClaims)
            .HasForeignKey(rc => rc.UserId);
        
        // OTHER
        // SEEDING
        modelBuilder.Entity<Role>()
            .HasData(new Role { Id = 1, Identifier = "Admin", Description = "Administrator" });
    }
}