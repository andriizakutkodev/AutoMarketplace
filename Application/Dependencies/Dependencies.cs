namespace Application.Dependencies;

using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Static class for registering application dependencies into the <see cref="IServiceCollection"/>.
/// </summary>
public static class Dependencies
{
    /// <summary>
    /// Registers application services into the provided <see cref="IServiceCollection"/> instance.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to register services with.</param>
    public static void Load(IServiceCollection services)
    {
        services.AddScoped<IPostsService, PostsService>();

        Persistence.Dependencies.Dependencies.Load(services);
    }
}
