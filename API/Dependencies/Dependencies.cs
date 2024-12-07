namespace API.Dependencies;

using API.Validators;
using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Interfaces;
using Persistence.Repositories;

/// <summary>
/// Static class for configuring and registering application dependencies in the dependency injection container.
/// Provides a centralized method to register services, repositories, and other components.
/// </summary>
public static class Dependencies
{
    /// <summary>
    /// Register all needed components to the IoC.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to register dependencies with.</param>
    public static void Load(IServiceCollection services)
    {
        RegisterServices(services);
        RegisterRepositories(services);
        RegisterValidators(services);
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IPostsService, PostsService>();
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Post>, PostsRepository>();
        services.AddScoped<IGenericRepository<Vehicle>, VehiclesRepository>();
        services.AddScoped<IGenericRepository<User>, UsersRepository>();
    }

    private static void RegisterValidators(IServiceCollection services)
    {
        services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();
        services.AddScoped<IValidator<RegisterDto>, RegisterDtoValidator>();
    }
}
