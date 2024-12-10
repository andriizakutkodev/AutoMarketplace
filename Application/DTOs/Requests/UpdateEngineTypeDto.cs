namespace Application.DTOs.Requests;

/// <summary>
/// Represents a data transfer object (DTO) for updating an existing engine type.
/// </summary>
public class UpdateEngineTypeDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the engine type to update.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the new name for the engine type.
    /// </summary>
    public string NewName { get; set; }
}
