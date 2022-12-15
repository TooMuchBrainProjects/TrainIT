using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class PresetRepository : ARepository<Preset>
{
    public PresetRepository(TrainITDbContext context) : base(context)
    {
    }
}