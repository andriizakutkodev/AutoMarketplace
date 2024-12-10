namespace Domain.Entities;

/// <summary>
/// Represents a type of vehicle.
/// </summary>
public class VehicleType : GenericType
{
    /// <summary>
    /// Gets or sets the collection of vehicle makes that use this engine type.
    /// </summary>
    public virtual ICollection<VehicleMake> Makes { get; set; }
}
