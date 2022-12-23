using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model.Configurations;
using Model.Entities;
using Model.Entities.Models;

namespace Domain.Repositories.Implementations;

public class UserRepository : ARepository<User>, IUserRepository
{
    public UserRepository(TrainITDbContext context) : base(context) { }
    
    public async Task<User?> FindByEmailAsync(string email, CancellationToken ct = default) {
        var user = await Table
            .AsSplitQuery() // <--- this is the magic
            .FirstOrDefaultAsync(u => u.Email == email, ct);

        return user?.ClearSensitiveData();
    }

    public async Task<User?> AuthorizeAsync(int id, CancellationToken ct = default) {
        var user = await Table
            .AsSplitQuery() // <--- this is the magic
            .FirstOrDefaultAsync(u => u.Id == id, ct);

        return user?.ClearSensitiveData();
    }

    public Task<User?> AuthorizeAsync(string token, CancellationToken ct = default) {
        throw new NotImplementedException("Bababum");
/*
        var user = await Table
            .Include(u => u.RoleClaims)
            .ThenInclude(rc => rc.Role)
            .AsSplitQuery() // <--- this is the magic
            .FirstOrDefaultAsync(u => false, ct);
        
        return user?.ClearSensitiveData();
*/
    }

    public async Task<User?> AuthorizeAsync(LoginModel model, CancellationToken ct = default) {
        var user = await Table
            .AsSplitQuery() // <--- this is the magic
            .FirstOrDefaultAsync(u => u.Email == model.Email, ct);

        if (user is null) return null;

        if (!User.VerifyPassword(model.Password, user.PasswordHashed)) return null!;

        return user.ClearSensitiveData();
    }
}