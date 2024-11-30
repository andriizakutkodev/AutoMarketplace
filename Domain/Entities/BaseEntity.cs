namespace Domain.Entities;

/// <summary>
/// Reproduce the base entity for all entities.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Gets or sets the id value.
    /// </summary>
    public Guid Id { get; set; }
}
