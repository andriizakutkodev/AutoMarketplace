namespace Domain.Entities;

/// <summary>
/// Represents a vehicle entity, containing detailed information about a specific vehicle.
/// </summary>
public class Vehicle : BaseEntity
{
    /// <summary>
    /// Gets or sets the type of vehicle (e.g., sedan, SUV, truck).
    /// </summary>
    public required string Type { get; set; }

    /// <summary>
    /// Gets or sets the manufacturer of the vehicle.
    /// </summary>
    public required string Make { get; set; }

    /// <summary>
    /// Gets or sets the model name of the vehicle.
    /// </summary>
    public required string Model { get; set; }

    /// <summary>
    /// Gets or sets the release date of the vehicle (e.g., production date).
    /// </summary>
    public DateTimeOffset ReleaseDate { get; set; }

    /// <summary>
    /// Gets or sets the type of engine used in the vehicle (e.g., inline-4, V6, electric).
    /// </summary>
    public required string EngineType { get; set; }

    /// <summary>
    /// Gets or sets the capacity of engine used in the vehicle.
    /// </summary>
    public required string EngineCapacityInfo { get; set; }

    /// <summary>
    /// Gets or sets the type of fuel the vehicle uses (e.g., gasoline, diesel, electric).
    /// </summary>
    public required string FuelType { get; set; }

    /// <summary>
    /// Gets or sets the mileage of the vehicle, typically measured in kilometers.
    /// </summary>
    public short Mileage { get; set; }
}
