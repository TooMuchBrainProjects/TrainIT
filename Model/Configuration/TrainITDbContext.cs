using Model.Entities;
using Model.Entities.Library;
using Model.Entities.Log;
using Model.Entities.per_User;

namespace Model.Configuration;

public class TrainITDbContext : DbContext
{
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseMuscleLibrary> ExerciseMuscleLibraries { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    public DbSet<ExerciseLibrary> ExerciseLibraries { get; set; }
    public DbSet<ExerciseLibraryMuscleLibrary> ExerciseLibraryMuscleLibraries { get; set; }
    public DbSet<MachineLibrary> MachineLibraries { get; set; }
    public DbSet<MuscleLibrary> MuscleLibraries { get; set; }
    public DbSet<WorkoutLibrary> WorkoutLibraries { get; set; }
    public DbSet<WorkoutLibraryExerciseLibrary> WorkoutLibraryExerciseLibraries { get; set; }
    
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
            .Property(le => le.FieldType)
            .HasConversion<string>();
        
        // FOREIGN KEYS
        
        // per User
        modelBuilder.Entity<Activity>()
            .HasOne(a => a.Exercise)
            .WithMany(e => e.Activities)
            .HasForeignKey(a => a.ExerciseId);
        
        modelBuilder.Entity<Exercise>()
            .HasOne(e => e.User)
            .WithMany(u => u.Exercises)
            .HasForeignKey(e => e.UserId);
        
        modelBuilder.Entity<ExerciseMuscleLibrary>()
            .HasOne(eml => eml.Exercise)
            .WithMany(e => e.ExerciseMuscleLibraries)
            .HasForeignKey(eml => eml.ExerciseId);
        
        modelBuilder.Entity<Workout>()
            .HasOne(w => w.User)
            .WithMany(u => u.Workouts)
            .HasForeignKey(w => w.UserId);
        
        modelBuilder.Entity<WorkoutExercise>()
            .HasOne(we => we.Exercise)
            .WithMany(e => e.WorkoutExercises)
            .HasForeignKey(we => we.ExerciseId);
        
        modelBuilder.Entity<WorkoutExercise>()
            .HasOne(we => we.Workout)
            .WithMany(w => w.WorkoutExercises)
            .HasForeignKey(we => we.WorkoutId);
        
        // per User - Library
        modelBuilder.Entity<Exercise>()
            .HasOne(e => e.MachineLibrary)
            .WithMany()
            .HasForeignKey(e => e.MachineLibraryId);
        
        modelBuilder.Entity<ExerciseMuscleLibrary>()
            .HasOne(eml => eml.MuscleLibrary)
            .WithMany()
            .HasForeignKey(eml => eml.MuscleLibraryId);
        
        // Library
        modelBuilder.Entity<ExerciseLibrary>()
            .HasOne(el => el.MachineLibrary)
            .WithMany(ml => ml.ExerciseLibraries)
            .HasForeignKey(el => el.MachineLibraryId);
        
        modelBuilder.Entity<ExerciseLibraryMuscleLibrary>()
            .HasOne(elml => elml.ExerciseLibrary)
            .WithMany(el => el.ExerciseLibraryMuscleLibraries)
            .HasForeignKey(elml => elml.ExerciseLibraryId);
        
        modelBuilder.Entity<ExerciseLibraryMuscleLibrary>()
            .HasOne(elml => elml.MuscleLibrary)
            .WithMany(ml => ml.ExerciseLibraryMuscleLibraries)
            .HasForeignKey(elml => elml.MuscleLibraryId);
        
        modelBuilder.Entity<WorkoutLibraryExerciseLibrary>()
            .HasOne(wlel => wlel.ExerciseLibrary)
            .WithMany(el => el.WorkoutLibraryExerciseLibraries)
            .HasForeignKey(wlel => wlel.ExerciseLibraryId);
        
        modelBuilder.Entity<WorkoutLibraryExerciseLibrary>()
            .HasOne(wlel => wlel.WorkoutLibrary)
            .WithMany(wl => wl.WorkoutLibraryExerciseLibraries)
            .HasForeignKey(wlel => wlel.WorkoutLibraryId);
        
        // Authentification
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
            .HasKey(we => new { we.ExerciseId, we.WorkoutId });
        
        modelBuilder.Entity<ExerciseMuscleLibrary>()
            .HasKey(eml => new { eml.ExerciseId, eml.MuscleLibraryId });
        
        modelBuilder.Entity<ExerciseLibraryMuscleLibrary>()
            .HasKey(elml => new { elml.ExerciseLibraryId, elml.MuscleLibraryId });
        
        modelBuilder.Entity<WorkoutLibraryExerciseLibrary>()
            .HasKey(wlel => new { wlel.WorkoutLibraryId, wlel.ExerciseLibraryId });
        
        // SEEDING
        modelBuilder.Entity<Role>()
            .HasData(new Role { Id = 1, Identifier = "Admin", Description = "Administrator" });
    }
}