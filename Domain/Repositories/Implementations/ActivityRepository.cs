using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class ActivityRepository : ARepository<Activity>, IActivityRepository
{
    public ActivityRepository(TrainITDbContext context) : base(context) { }


    public async Task<Activity> GetActivityById(int subexerciseId, CancellationToken ct = default)
    {
        return await Table
            .Where(s => s.Id == subexerciseId)
            .FirstAsync(cancellationToken: ct);
    }

    public async Task<List<Activity>> GetActivitiesByUser(int userId, CancellationToken ct = default)
    {
        return await Table
            .Include(s => s.Exercise)
            .Where(s => s.Exercise.UserId == userId)
            .ToListAsync(cancellationToken: ct);
    }

    public async Task<List<Activity>> GetActivitiesByDate(DateOnly date, CancellationToken ct = default)
    {
        return await Table
            .Include(s => s.Exercise)
            .Where(s => s.DateValue == date)
            .ToListAsync(cancellationToken: ct);
    }

    public async Task<List<Activity>> GetActivitiesByUserByDate(int userId, DateOnly date, CancellationToken ct = default)
    {
        return await Table
            .Include(s => s.Exercise)
            .Where(s => s.Exercise.UserId == userId && s.DateValue == date)
            .ToListAsync(cancellationToken: ct);
    }
}