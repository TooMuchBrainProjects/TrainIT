using Model.Entities;

namespace Domain.Repositories.Interfaces;

public interface IActivityRepository : IRepository<Activity>
{
    Task<Activity> GetActivityById(int subexerciseId, CancellationToken ct = default);
    Task<List<Activity>> GetActivitiesByUser(int userId, CancellationToken ct = default);
    Task<List<Activity>> GetActivitiesByDate(DateOnly date, CancellationToken ct = default);
    Task<List<Activity>> GetActivitiesByUserByDate(int userId, DateOnly date, CancellationToken ct = default);
}