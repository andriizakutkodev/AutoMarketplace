namespace Domain.Entities;

/// <summary>
/// Represents a type of fuel used in vehicles.
/// </summary>
public class FuelType : GenericType
{
    /// <summary>
    /// Gets or sets the collection of vehicle models that use this fuel type.
    /// </summary>
    public virtual ICollection<VehicleModel> Models { get; set; }
}
