using Model.Entities.per_User;

namespace Domain.Repositories.Implementations;

public class ExerciseMuscleAssetRepository : ARepository<ExerciseMuscleAsset>, IExerciseMuscleAssetRepository
{
    public ExerciseMuscleAssetRepository(TrainITDbContext context) : base(context)
    {
    }
}