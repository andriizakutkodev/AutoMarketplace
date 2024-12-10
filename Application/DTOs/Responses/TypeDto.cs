namespace Application.DTOs.Responses;

/// <summary>
/// Represents a data transfer object (DTO) for a type.
/// </summary>
public class TypeDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the type.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the type.
    /// </summary>
    public string Name { get; set; }
}
