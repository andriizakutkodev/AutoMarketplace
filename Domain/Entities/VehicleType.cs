namespace Domain.Entities;

/// <summary>
/// Represents a type of vehicle.
/// </summary>
public class VehicleType : BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the vehicle type.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the collection of vehicle makes that use this engine type.
    /// </summary>
    public virtual ICollection<VehicleMake> Makes { get; set; }
}
