namespace Application.DTOs.Requests;

/// <summary>
/// Data transfer object for creating a new vehicle model.
/// </summary>
public class CreateVehicleModelDto
{
    /// <summary>
    /// Gets or sets the name of the vehicle model.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the engine capacity of the vehicle model in cubic centimeters (cc).
    /// </summary>
    public int EngineCapacity { get; set; }

    /// <summary>
    /// Gets or sets the release date of the vehicle model.
    /// </summary>
    public DateTimeOffset ReleaseDate { get; set; }

    /// <summary>
    /// Gets or sets the vehicle make identifier associated with vehicle make.
    /// </summary>
    public Guid VehicleMakeId { get; set; }

    /// <summary>
    /// Gets or sets the engine type identifier associated with engine type.
    /// </summary>
    public Guid EngineTypeId { get; set; }

    /// <summary>
    /// Gets or sets the fuel type identifier associated with fuel type.
    /// </summary>
    public Guid FuelTypeId { get; set; }
}
