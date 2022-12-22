using Model.Entities;

namespace Domain.Repositories.Interfaces;

public interface IExerciseRepository : IRepository<Exercise>
{
    Task<Exercise> GetExerciseById(int exerciseId, CancellationToken ct = default);
    Task<Exercise> GetExerciseBySubexercise(int subExerciseId, CancellationToken ct = default);
    Task<List<Exercise>> GetExercisesBySubexercises(List<int> subExerciseIds, CancellationToken ct = default);
    Task<List<Exercise>> GetExercisesByUser(int userId, CancellationToken ct = default);
    Task<List<Exercise>> GetExercisesByPreset(int presetId, CancellationToken ct = default);
    Task<List<Exercise>> GetExercisesByUserByPreset(int userId, int presetId, CancellationToken ct = default);
}