using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class SubExerciseRepository : ARepository<SubExercise>, ISubExerciseRepository
{
    public SubExerciseRepository(TrainITDbContext context) : base(context)
    {
    }

    public async Task<List<SubExercise>> GetSubExercisesByDate(int userId, DateOnly date,
        CancellationToken ct = default)
    {
        return await Table
            .Include(s => s.Exercise)
            .Where(s => s.Exercise.UserId == userId && s.DateValue == date)
            .ToListAsync(cancellationToken: ct);
    }
}