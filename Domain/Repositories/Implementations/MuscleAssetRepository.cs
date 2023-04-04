using Model.Entities.Assets;

namespace Domain.Repositories.Implementations;

public class MuscleAssetRepository : ARepository<MuscleAsset>, IMuscleAssetRepository
{
    public MuscleAssetRepository(TrainITDbContext context) : base(context)
    {
    }
}