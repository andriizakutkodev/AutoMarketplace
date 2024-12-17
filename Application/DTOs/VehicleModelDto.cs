namespace Application.DTOs;

/// <summary>
/// Represents a Data Transfer Object (DTO) containing vehicle model information.
/// </summary>
public class VehicleModelDto
{
    /// <summary>
    /// Gets or sets the unique identifier of vehicle model.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the vehicle model.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the engine capacity info for model.
    /// </summary>
    public int EngineCapacity { get; set; }

    /// <summary>
    /// Gets or sets the make (manufacturer) of the vehicle model.
    /// </summary>
    public string Make { get; set; }

    /// <summary>
    /// Gets or sets the engine type of the vehicle.
    /// </summary>
    public string VehicleType { get; set; }

    /// <summary>
    /// Gets or sets the engine type of the vehicle.
    /// </summary>
    public string EngineType { get; set; }

    /// <summary>
    /// Gets or sets the release date of the vehicle (e.g., production date).
    /// </summary>
    public DateTimeOffset ReleaseDate { get; set; }
}
