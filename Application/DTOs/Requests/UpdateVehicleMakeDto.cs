namespace Application.DTOs.Requests;

using Application.DTOs.Responses;

/// <summary>
/// Represents a data transfer object (DTO) for updating a new vehicle make.
/// </summary>
public class UpdateVehicleMakeDto
{
    /// <summary>
    /// Gets or sets the unique identifier of vehicle make to update.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the vehicle make to be created.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the data transfer object (DTO) containing vehicle type information.
    /// </summary>
    public TypeDto Type { get; set; }
}
