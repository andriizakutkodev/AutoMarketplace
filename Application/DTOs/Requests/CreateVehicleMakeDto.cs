namespace Application.DTOs.Requests;

/// <summary>
/// Represents a data transfer object (DTO) for creating a new vehicle make.
/// </summary>
public class CreateVehicleMakeDto
{
    /// <summary>
    /// Gets or sets the name of the vehicle make to be created.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the vechicle type identifier to be used during creating.
    /// </summary>
    public Guid VehicleTypeId { get; set; }
}
