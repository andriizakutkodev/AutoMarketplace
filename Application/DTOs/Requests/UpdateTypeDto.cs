namespace Application.DTOs.Requests;

/// <summary>
/// Represents a data transfer object (DTO) for updating an existing type.
/// </summary>
public class UpdateTypeDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the type to update.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the new name for the type.
    /// </summary>
    public string Name { get; set; }
}
