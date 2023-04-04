using Model.Entities.Assets;

namespace Domain.Repositories.Implementations;

public class ExerciseAssetRepository : ARepository<ExerciseAsset>, IExerciseAssetRepository
{
    public ExerciseAssetRepository(TrainITDbContext context) : base(context)
    {
    }
}