using Model.Entities;

namespace Domain.Repositories.Interfaces;

public interface ISubExerciseRepository : IRepository<SubExercise>
{
    Task<List<SubExercise>> GetSubExercisesByDate(int userId, DateOnly date, CancellationToken ct = default);
}