namespace Application.DTOs.Requests;

/// <summary>
/// Represents a data transfer object (DTO) for updating an existing fuel type.
/// </summary>
public class UpdateFuelTypeDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the fuel type to update.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the new name for the fuel type.
    /// </summary>
    public string NewName { get; set; }
}
