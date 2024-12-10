namespace Domain.Entities;

/// <summary>
/// Represents a type of engine used in vehicles.
/// </summary>
public class EngineType : GenericType
{
    /// <summary>
    /// Gets or sets the collection of vehicle models that use this engine type.
    /// </summary>
    public virtual ICollection<VehicleModel> Models { get; set; }
}
