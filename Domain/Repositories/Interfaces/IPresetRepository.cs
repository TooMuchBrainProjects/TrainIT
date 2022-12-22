using Model.Entities;

namespace Domain.Repositories.Interfaces;

public interface IPresetRepository : IRepository<Preset>
{
    Task<List<Preset>> GetPresetByUserId(int userId, CancellationToken ct = default);
}