namespace Application.DTOs.Requests;

/// <summary>
/// Represents a data transfer object (DTO) for creating a new engine type.
/// </summary>
public class CreateEngineTypeDto
{
    /// <summary>
    /// Gets or sets the name of the engine type to be created.
    /// </summary>
    public string Name { get; set; }
}
