using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class ExerciseRepository : ARepository<Exercise>, IExerciseRepository
{
    public ExerciseRepository(TrainITDbContext context) : base(context)
    {
        
    }
}