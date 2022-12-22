using Domain.Repositories.Interfaces;
using Model.Entities;

public interface IPresetExerciseRepository : IRepository<PresetExercise>
{
    Task<List<Exercise>> GetExercisesByPreset(int userId, DateOnly date, CancellationToken ct = default);
    
}