﻿using Model.Entities;
using Model.Entities.Models;

namespace Domain.Repositories.Interfaces;

public interface IUserRepository : IRepository<User> 
{
    Task<User?> FindByEmailAsync(string email, CancellationToken ct = default);
    Task<User?> AuthorizeAsync(int id, CancellationToken ct = default);
    Task<User?> AuthorizeAsync(string token, CancellationToken ct = default);
    Task<User?> AuthorizeAsync(LoginModel model, CancellationToken ct = default);
}