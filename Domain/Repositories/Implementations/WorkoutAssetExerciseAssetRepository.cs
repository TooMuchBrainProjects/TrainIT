using Model.Entities.Assets;

namespace Domain.Repositories.Implementations;

public class WorkoutAssetExerciseAssetRepository : ARepository<WorkoutAssetExerciseAsset>, IWorkoutAssetExerciseAssetRepository
{
    public WorkoutAssetExerciseAssetRepository(TrainITDbContext context) : base(context)
    {
    }
}