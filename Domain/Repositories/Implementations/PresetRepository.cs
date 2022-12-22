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

    public async Task<List<Preset>> GetPresetByUserId(int userId, CancellationToken ct = default)
    {
        return await Context.Presets
            .Join(Context.PresetExercises, p => p.Id, eep => eep.PresetId, (p, eep) => new { p, eep })
            .Join(Context.Exercises, eep => eep.eep.ExerciseId, e => e.Id, (eep, e) => new { eep, e })
            .Where(result => result.e.UserId == 1)
            .Select(result => result.eep.p)
            .ToListAsync();
    }
}