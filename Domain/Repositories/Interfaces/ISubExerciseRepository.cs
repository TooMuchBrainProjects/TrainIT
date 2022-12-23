using Model.Entities;

namespace Domain.Repositories.Interfaces;

public interface ISubExerciseRepository : IRepository<SubExercise>
{
    Task<SubExercise> GetSubexerciseById(int subexerciseId, CancellationToken ct = default);
    Task<List<SubExercise>> GetSubexercisesByUser(int userId, CancellationToken ct = default);
    Task<List<SubExercise>> GetSubexercisesByDate(DateOnly date, CancellationToken ct = default);
    Task<List<SubExercise>> GetSubexercisesByUserByDate(int userId, DateOnly date, CancellationToken ct = default);
}