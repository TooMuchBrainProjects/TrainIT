using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class SubExerciseRepository : ARepository<SubExercise>, ISubExerciseRepository
{
    public SubExerciseRepository(TrainITDbContext context) : base(context) { }


    public async Task<SubExercise> GetSubexerciseById(int subexerciseId, CancellationToken ct = default)
    {
        return await Table
            .Where(s => s.Id == subexerciseId)
            .FirstAsync(cancellationToken: ct);
    }

    public async Task<List<SubExercise>> GetSubexercisesByUser(int userId, CancellationToken ct = default)
    {
        return await Table
            .Include(s => s.Exercise)
            .Where(s => s.Exercise.UserId == userId)
            .ToListAsync(cancellationToken: ct);
    }

    public async Task<List<SubExercise>> GetSubexercisesByDate(DateOnly date, CancellationToken ct = default)
    {
        return await Table
            .Include(s => s.Exercise)
            .Where(s => s.DateValue == date)
            .ToListAsync(cancellationToken: ct);
    }

    public async Task<List<SubExercise>> GetSubexercisesByUserByDate(int userId, DateOnly date, CancellationToken ct = default)
    {
        return await Table
            .Include(s => s.Exercise)
            .Where(s => s.Exercise.UserId == userId && s.DateValue == date)
            .ToListAsync(cancellationToken: ct);
    }
}