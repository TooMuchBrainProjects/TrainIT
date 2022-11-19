﻿using Domain.Exceptions;
using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Model.Entities;
using Model.Entities.Models;

namespace WebGui.Services;

public class UserService {

    public User? CurrentUser => _authenticationStateProvider.CurrentUser;
    
    public Task<AuthenticationState> GetAuthenticationStateAsync() => _authenticationStateProvider.GetAuthenticationStateAsync();

    private readonly CustomAuthStateProvider _authenticationStateProvider;

    private readonly IUserRepository _userRepository;

    public UserService(AuthenticationStateProvider authenticationStateProvider, IUserRepository userRepository) {
        _authenticationStateProvider = authenticationStateProvider
                                           as CustomAuthStateProvider ??
                                       throw new NullReferenceException(
                                           "I Guess you forgot to add the CustomAuthStateProvider to the Dependency Injection container");
        _userRepository = userRepository;
    }

    public async Task<bool> IsAuthenticated() {
        var identity = await _authenticationStateProvider.GetAuthenticationStateAsync();
        return identity.User.Identity is { IsAuthenticated: true };
    }

    public async Task RegisterAsync(User user, CancellationToken ct = default) {
        // check for unique stuff
        var userExists = await _userRepository.FindByEmailAsync(user.Email, ct);
        if (userExists != null)
            throw new DuplicateEmailException();

        user.PasswordHashed = User.HashPassword(user.Password);
        await _userRepository.CreateAsync(user, ct);
    }

    public async Task LoginAsync(LoginModel loginModel, CancellationToken ct = default) {
        var user = await _userRepository.AuthorizeAsync(loginModel, ct);
        if (user is null)
            throw new LoginException();

        await _authenticationStateProvider.Login(user);
    }

    public async Task LogoutAsync() {
        await _authenticationStateProvider.Logout();
    }
}