namespace API.Extensions;

using Infrastructure.Data;
using Infrastructure.Dependencies;

using Microsoft.EntityFrameworkCore;

/// <summary>
/// Provides extension methods for registering dependencies into the <see cref="IServiceCollection"/>.
/// This method simplifies the process of loading application-specific dependencies.
/// </summary>
public static class ProgramExtensions
{
    /// <summary>
    /// Registers application dependencies by calling the <see cref="Dependencies.Load"/> method.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to register dependencies with.</param>
    public static void RegisterDependencies(this IServiceCollection services)
    {
        Dependencies.Load(services);
    }

    /// <summary>
    /// Registers the <see cref="AppDbContext"/> with the dependency injection container.
    /// Configures the context to use PostgreSQL with the connection string from the configuration.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to register the <see cref="AppDbContext"/> with.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> containing the connection string for the database.</param>
    public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("Default"), b =>
            {
                b.MigrationsAssembly(typeof(AppDbContext).Assembly);
            });
        });
    }
}
