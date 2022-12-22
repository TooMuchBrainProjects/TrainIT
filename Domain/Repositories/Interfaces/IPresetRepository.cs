using Model.Entities;

namespace Domain.Repositories.Interfaces;

public interface IPresetRepository : IRepository<Preset>
{
    Task<Exercise> GetPresetById(int presetId, CancellationToken ct = default);
    Task<List<Preset>> GetPresetsByUser(int userId, CancellationToken ct = default);
    Task<List<Preset>> GetPresetsByExercise(int exerciseId, CancellationToken ct = default);
}