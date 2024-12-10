namespace Application.DTOs.Responses;

/// <summary>
/// Represents a data transfer object (DTO) for an engine type.
/// Used to transfer engine type data between application layers.
/// </summary>
public class EngineTypeDto
{
    /// <summary>
    /// Gets or sets the unique identifier for the engine type.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the engine type.
    /// </summary>
    public string Name { get; set; }
}
