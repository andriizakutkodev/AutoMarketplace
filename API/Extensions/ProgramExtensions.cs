namespace API.Extensions;

using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using API.Validators;
using Application.DTOs.Requests;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using FluentValidation;
using Persistence.Interfaces;
using Persistence.Repositories;
using Application.Options;

/// <summary>
/// Provides extension methods for registering dependencies into the <see cref="IServiceCollection"/>.
/// This method simplifies the process of loading application-specific dependencies.
/// </summary>
public static class ProgramExtensions
{
    /// <summary>
    /// Registers application dependencies.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to register dependencies with.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> to get access to config.</param>
    public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterDbContext(services, configuration);
        RegisterServices(services);
        RegisterRepositories(services);
        RegisterValidators(services);
        RegisterOptions(services, configuration);
    }

    private static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("Default"), b =>
            {
                b.MigrationsAssembly(typeof(AppDbContext).Assembly);
            });
        });
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IPostsService, PostsService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddSingleton<IPasswordHandlerService, PasswordHandlerService>();
        services.AddSingleton<IJwtService, JwtService>();
        services.AddScoped<IAuthService, AuthService>();
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IPostsRepository, PostsRepository>();
        services.AddScoped<IVehiclesRepository, VehiclesRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
    }

    private static void RegisterValidators(IServiceCollection services)
    {
        services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();
        services.AddScoped<IValidator<RegisterDto>, RegisterDtoValidator>();
    }

    private static void RegisterOptions(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
    }
}
