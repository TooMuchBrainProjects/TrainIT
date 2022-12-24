using Model.Entities;

namespace Domain.Repositories.Interfaces;

public interface IWorkoutRepository : IRepository<Workout>
{
    Task<Workout> GetWorkoutById(int workoutId, CancellationToken ct = default);
    Task<List<Workout>> GetWorkoutsByUser(int userId, CancellationToken ct = default);
    Task<List<Workout>> GetWorkoutsByExercise(int exerciseId, CancellationToken ct = default);
}