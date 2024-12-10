namespace Domain.Entities;

/// <summary>
/// Represents a type of fuel used in vehicles.
/// </summary>
public class FuelType : BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the fuel type.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the collection of vehicle models that use this fuel type.
    /// </summary>
    public virtual ICollection<VehicleModel> Models { get; set; }
}
