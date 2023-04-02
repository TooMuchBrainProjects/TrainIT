using Model.Entities.per_User;

namespace Domain.Repositories.Implementations;

public class WorkoutExerciseRepository : ARepository<WorkoutExercise>, IWorkoutExerciseRepository
{
    public WorkoutExerciseRepository(TrainITDbContext context) : base(context)
    {
    }
}