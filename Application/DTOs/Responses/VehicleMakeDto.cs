namespace Application.DTOs.Responses;

/// <summary>
/// Represents a data transfer object (DTO) containing vehicle make information.
/// </summary>
public class VehicleMakeDto
{
    /// <summary>
    /// Gets or sets the unique identifier for vehicle make.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the vehicle name value.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the data transfer object (DTO) containing vehicle type information.
    /// </summary>
    public TypeDto Type { get; set; }
}
