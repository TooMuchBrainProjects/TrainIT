﻿global using System.Diagnostics;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Components.Server.Circuits;
global using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.RazorPages;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.Extensions.Logging.Abstractions;

global using MudBlazor;
global using MudBlazor.Services;

global using Domain.Exceptions;
global using Domain.Repositories.Implementations;
global using Domain.Repositories.Interfaces;

global using Model.Configuration;
global using Model.Entities;
global using Model.Entities.Assets;
global using Model.Entities.Authentication;
global using Model.Entities.Log;
global using Model.Entities.per_User;
global using Model.Entities.Authentication.Models;

global using View;
global using View.Services;