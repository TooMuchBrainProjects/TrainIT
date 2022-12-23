using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class WorkoutRepository : ARepository<Workout>, IWorkoutRepository
{
    public WorkoutRepository(TrainITDbContext context) : base(context)
    {
    }

    public async Task<Workout> GetWorkoutById(int presetId, CancellationToken ct = default)
    {
        return await Table
            .Where(p => p.Id == presetId)
            .FirstAsync(cancellationToken: ct);
    }

    public async Task<List<Workout>> GetWorkoutsByUser(int userId, CancellationToken ct = default)
    {
        return await
            (Context.Set<Workout>()
                .Join(Context.Set<WorkoutExercise>(), preset => preset.Id, presetExercise => presetExercise.WorkoutId,
                    (preset, presetExercise) => new { preset, PresetExercise = presetExercise })
                .Join(Context.Set<Exercise>(), @t => @t.PresetExercise.ExerciseId, exercise => exercise.Id,
                    (@t, exercise) => new { @t, Exercise = exercise })
                .Where(@t => @t.Exercise.UserId == userId)
                .Select(@t => @t.@t.preset))
            .ToListAsync(cancellationToken: ct);
    }

    public async Task<List<Workout>> GetWorkoutsByExercise(int exerciseId, CancellationToken ct = default)
    {
        return await
            (Context.Set<Workout>()
                .Join(Context.Set<WorkoutExercise>(), preset => preset.Id, presetExercise => presetExercise.WorkoutId,
                    (preset, presetExercise) => new { preset, presetExercise })
                .Join(Context.Set<Exercise>(), @t => @t.presetExercise.ExerciseId, exercise => exercise.Id,
                    (@t, exercise) => new { @t, exercise })
                .Where(@t => @t.exercise.Id == exerciseId)
                .Select(@t => @t.@t.preset))
            .ToListAsync(cancellationToken: ct);
    }
}