using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Implementations;

public class UserRepository : ARepository<User>
{
    public UserRepository(TrainITDbContext context) : base(context)
    {
    }
}