using Model.Entities.Assets;

namespace Domain.Repositories.Implementations;

public class WorkoutAssetRepository : ARepository<WorkoutAsset>, IWorkoutAssetRepository
{
    public WorkoutAssetRepository(TrainITDbContext context) : base(context)
    {
    }
}