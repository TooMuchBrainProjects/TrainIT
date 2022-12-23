using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class ExerciseRepository : ARepository<Exercise>, IExerciseRepository
{
    public ExerciseRepository(TrainITDbContext context) : base(context)
    {
    }

    public async Task<Exercise> GetExerciseById(int exerciseId, CancellationToken ct = default)
    {
        return await Table
            .Where(e => e.Id == exerciseId)
            .FirstAsync(cancellationToken: ct);
    }

    public async Task<Exercise> GetExerciseByActivity(int subExerciseId, CancellationToken ct = default)
    {
        return await Context.Set<Exercise>()
            .Join(Context.Set<Activity>(), exercise => exercise.Id, subExercise => subExercise.ExerciseId,
                (exercise, subExercise) => new { exercise, subExercise })
            .Where(@t => @t.subExercise.Id == subExerciseId)
            .Select(@t => @t.exercise)
            .FirstAsync(cancellationToken: ct);
    }

    public async Task<List<Exercise>> GetExercisesByActivities(IEnumerable<int> subExerciseIds,
        CancellationToken ct = default)
    {
        return await Context.Set<Exercise>()
            .Join(Context.Set<Activity>(), exercise => exercise.Id, subExercise => subExercise.ExerciseId,
                (exercise, subExercise) => new { exercise, subExercise })
            .Where(@t => subExerciseIds.Contains(@t.subExercise.Id))
            .Select(@t => @t.exercise)
            .ToListAsync(cancellationToken: ct);
    }

    public async Task<List<Exercise>> GetExercisesByUser(int userId, CancellationToken ct = default)
    {
        return await Table
            .Include(e => e.User)
            .Where(e => e.User.Id == userId)
            .ToListAsync(cancellationToken: ct);
    }

    public async Task<List<Exercise>> GetExercisesByWorkout(int workoutId, CancellationToken ct = default)
    {
        return await Context.Set<Exercise>()
            .Join(Context.Set<WorkoutExercise>(), exercise => exercise.Id,
                presetExercise => presetExercise.ExerciseId,
                (exercise, presetExercise) => new { exercise, presetExercise })
            .Join(Context.Set<Workout>(), @t => @t.presetExercise.ExerciseId, preset => preset.Id,
                (@t, preset) => new { @t, preset })
            .Where(@t => @t.preset.Id == workoutId)
            .Select(@t => @t.@t.exercise)
            .ToListAsync(cancellationToken: ct);
    }

    public async Task<List<Exercise>> GetExercisesByUserByWorkout(int userId, int workoutId,
        CancellationToken ct = default)
    {
        return await Context.Set<Exercise>()
            .Join(Context.Set<WorkoutExercise>(), exercise => exercise.Id,
                presetExercise => presetExercise.ExerciseId,
                (exercise, presetExercise) => new { exercise, presetExercise })
            .Join(Context.Set<Workout>(), @t => @t.presetExercise.ExerciseId, preset => preset.Id,
                (@t, preset) => new { @t, preset })
            .Where(@t => @t.preset.Id == workoutId)
            .Where(@t => @t.@t.exercise.UserId == userId)
            .Select(@t => @t.@t.exercise)
            .ToListAsync(cancellationToken: ct);
    }
}