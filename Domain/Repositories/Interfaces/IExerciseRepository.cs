using Model.Entities;

namespace Domain.Repositories.Interfaces;

public interface IExerciseRepository : IRepository<Exercise>
{
    Task<Exercise> GetExerciseById(int exerciseId, CancellationToken ct = default);
    Task<Exercise> GetExerciseByActivity(int subExerciseId, CancellationToken ct = default);
    Task<List<Exercise>> GetExercisesByActivities(IEnumerable<int> subExerciseIds, CancellationToken ct = default);
    Task<List<Exercise>> GetExercisesByUser(int userId, CancellationToken ct = default);
    Task<List<Exercise>> GetExercisesByWorkout(int workoutId, CancellationToken ct = default);
    Task<List<Exercise>> GetExercisesByUserByWorkout(int userId, int workoutId, CancellationToken ct = default);
}