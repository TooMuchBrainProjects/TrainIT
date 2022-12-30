namespace Domain.Repositories.Implementations;

public class RoleRepository : ARepository<Role>, IRoleRepository {
    public RoleRepository(TrainITDbContext context) : base(context) {
    }
}