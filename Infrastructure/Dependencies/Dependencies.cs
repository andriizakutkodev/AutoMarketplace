namespace Infrastructure.Dependencies;

using Application.Interfaces;
using Application.Services;
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
    /// Registers application services and repositories into the provided <see cref="IServiceCollection"/> instance.
    /// This includes business logic services and data access layer components.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to register dependencies with.</param>
    public static void Load(IServiceCollection services)
    {
        services.AddScoped<IPostsService, PostsService>();

        services.AddScoped<IPostsRepository, PostsRepository>();
        services.AddScoped<IVehiclesRepository, VehiclesRepository>();
    }
}
