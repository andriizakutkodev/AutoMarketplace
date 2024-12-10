namespace Domain.Entities;

/// <summary>
/// Represents a type of engine used in vehicles.
/// </summary>
public class EngineType : BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the engine type.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the collection of vehicle models that use this engine type.
    /// </summary>
    public virtual ICollection<VehicleModel> Models { get; set; }
}
