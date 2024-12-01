namespace Persistence.Dependencies;

using Microsoft.Extensions.DependencyInjection;
using Persistence.Interfaces;
using Persistence.Repositories;

/// <summary>
/// Static class for registering application dependencies into the <see cref="IServiceCollection"/>.
/// </summary>
public static class Dependencies
{
    /// <summary>
    /// Registers application services and repositories into the provided <see cref="IServiceCollection"/> instance.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to register dependencies with.</param>
    public static void Load(IServiceCollection services)
    {
        services.AddScoped<IPostsRepository, PostsRepository>();
        services.AddScoped<IVehiclesRepository, VehiclesRepository>();
    }
}
