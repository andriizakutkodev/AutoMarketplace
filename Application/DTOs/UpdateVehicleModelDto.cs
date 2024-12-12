namespace Application.DTOs;

/// <summary>
/// Data transfer object for updating a vehicle model.
/// </summary>
public class UpdateVehicleModelDto : VehicleModelDto
{
    /// <summary>
    /// Gets or sets the unique identifier of vehicle model.
    /// </summary>
    public Guid Id { get; set; }
}
