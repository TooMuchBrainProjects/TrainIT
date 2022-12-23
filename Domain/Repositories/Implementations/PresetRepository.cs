using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class PresetRepository : ARepository<Preset>, IPresetRepository
{
    public PresetRepository(TrainITDbContext context) : base(context)
    {
    }

    public async Task<Preset> GetPresetById(int presetId, CancellationToken ct = default)
    {
        return await Table
            .Where(p => p.Id == presetId)
            .FirstAsync(cancellationToken: ct);
    }

    public async Task<List<Preset>> GetPresetsByUser(int userId, CancellationToken ct = default)
    {
        return await
            (Context.Set<Preset>()
                .Join(Context.Set<PresetExercise>(), preset => preset.Id, presetExercise => presetExercise.PresetId,
                    (preset, presetExercise) => new { preset, PresetExercise = presetExercise })
                .Join(Context.Set<Exercise>(), @t => @t.PresetExercise.ExerciseId, exercise => exercise.Id,
                    (@t, exercise) => new { @t, Exercise = exercise })
                .Where(@t => @t.Exercise.UserId == userId)
                .Select(@t => @t.@t.preset))
            .ToListAsync(cancellationToken: ct);
    }

    public async Task<List<Preset>> GetPresetsByExercise(int exerciseId, CancellationToken ct = default)
    {
        return await
            (Context.Set<Preset>()
                .Join(Context.Set<PresetExercise>(), preset => preset.Id, presetExercise => presetExercise.PresetId,
                    (preset, presetExercise) => new { preset, presetExercise })
                .Join(Context.Set<Exercise>(), @t => @t.presetExercise.ExerciseId, exercise => exercise.Id,
                    (@t, exercise) => new { @t, exercise })
                .Where(@t => @t.exercise.Id == exerciseId)
                .Select(@t => @t.@t.preset))
            .ToListAsync(cancellationToken: ct);
    }
}