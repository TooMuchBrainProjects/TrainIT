using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class SubExerciseRepository : ARepository<SubExercise>
{
    public SubExerciseRepository(TrainITDbContext context) : base(context)
    {
        
    }
}