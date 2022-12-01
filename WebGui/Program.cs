using Domain.Repositories.Implementations;
using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;
using WebGui.Data;
using MudBlazor.Services;
using View.Services;
using WebGui.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthenticationCore();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// then we can add the Options
// this adds services we need
builder.Services.AddOptions();

builder.Services.AddDbContextFactory<TrainITDbContext>(
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 27))
    )
);

// MudBlazor
builder.Services.AddMudServices();

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRepository<Exercise>, ExerciseRepository>();
builder.Services.AddScoped<ISubExerciseRepository, SubExerciseRepository>();

builder.Services.AddLogging(); // the default Logger

builder.Services.AddHttpContextAccessor(); // this services enables us to access to HttpContext of our App

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>(); // we register our implementation of the AuthenticationStateProvider

builder.Services.AddScoped<UserService>(); // The UserService we use to login/register/logout

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();