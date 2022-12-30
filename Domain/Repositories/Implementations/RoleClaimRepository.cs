namespace Domain.Repositories.Implementations;

public class RoleClaimRepository : ARepository<RoleClaim>, IRoleClaimRepository {
    public RoleClaimRepository(TrainITDbContext context) : base(context) {
    }
}