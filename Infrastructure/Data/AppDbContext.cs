namespace Infrastructure.Data;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Represents the Application Db Context.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AppDbContext"/> class.
/// </remarks>
/// <param name="ops">Db context options.</param>
public class AppDbContext(DbContextOptions<AppDbContext> ops)
    : DbContext(ops)
{
    /// <summary>
    /// Gets or sets the db set of fuel types.
    /// </summary>
    public DbSet<FuelType> FuelTypes { get; set; }

    /// <summary>
    /// Gets or sets the db set of engine types.
    /// </summary>
    public DbSet<EngineType> EngineTypes { get; set; }

    /// <summary>
    /// Gets or sets the db set of vehicle types.
    /// </summary>
    public DbSet<VehicleType> VehicleTypes { get; set; }

    /// <summary>
    /// Gets or sets the db set of vehicle makes.
    /// </summary>
    public DbSet<VehicleMake> VehicleMakes { get; set; }

    /// <summary>
    /// Gets or sets the db set of vehicle models.
    /// </summary>
    public DbSet<VehicleModel> VehicleModels { get; set; }

    /// <summary>
    /// Gets or sets the db set of posts.
    /// </summary>
    public DbSet<Post> Posts { get; set; }

    /// <summary>
    /// Gets or sets the db set of users.
    /// </summary>
    public DbSet<User> Users { get; set; }
}
