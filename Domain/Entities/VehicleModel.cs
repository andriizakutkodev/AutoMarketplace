namespace Domain.Entities;

/// <summary>
/// Represents a specific model of a vehicle.
/// </summary>
public class VehicleModel : BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the vehicle model.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the engine capacity info for model.
    /// </summary>
    public int EngineCapacity { get; set; }

    /// <summary>
    /// Gets or sets the release date of the vehicle (e.g., production date).
    /// </summary>
    public DateTimeOffset ReleaseDate { get; set; }

    /// <summary>
    /// Gets or sets the make (manufacturer) of the vehicle model.
    /// </summary>
    public virtual VehicleMake Make { get; set; }

    /// <summary>
    /// Gets or sets the engine type of the vehicle.
    /// </summary>
    public virtual EngineType EngineType { get; set; }

    /// <summary>
    /// Gets or sets the fuel type of the vehicle.
    /// </summary>
    public virtual FuelType FuelType { get; set; }
}
