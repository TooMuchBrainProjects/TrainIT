using Model.Entities.Assets;

namespace Domain.Repositories.Implementations;

public class MachineAssetRepository : ARepository<MachineAsset>, IMachineAssetRepository
{
    public MachineAssetRepository(TrainITDbContext context) : base(context)
    {
    }
}