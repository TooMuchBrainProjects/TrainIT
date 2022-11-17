using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class ExerciseRepository : ARepository<Exercise>
{
    public ExerciseRepository(TrainITDbContext context) : base(context)
    {
        
    }
}