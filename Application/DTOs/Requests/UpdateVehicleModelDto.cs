namespace Application.DTOs.Requests;

using Application.DTOs.Responses;

/// <summary>
/// Data transfer object for updating a vehicle model.
/// </summary>
public class UpdateVehicleModelDto
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
    /// Gets or sets the release date of the vehicle (e.g., production date).
    /// </summary>
    public DateTimeOffset ReleaseDate { get; set; }

    /// <summary>
    /// Gets or sets the make (manufacturer) of the vehicle model.
    /// </summary>
    public TypeDto Make { get; set; }

    /// <summary>
    /// Gets or sets the engine type of the vehicle.
    /// </summary>
    public TypeDto EngineType { get; set; }

    /// <summary>
    /// Gets or sets the fuel type of the vehicle.
    /// </summary>
    public TypeDto FuelType { get; set; }
}
