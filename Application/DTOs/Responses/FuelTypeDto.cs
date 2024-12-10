namespace Application.DTOs.Responses;

/// <summary>
/// Represents a data transfer object (DTO) for a fuel type.
/// </summary>
public class FuelTypeDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the fuel type.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the fuel type.
    /// </summary>
    public string Name { get; set; }
}
