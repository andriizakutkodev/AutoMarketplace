namespace Domain.Entities;

/// <summary>
/// Represents a manufacturer or brand of vehicles.
/// </summary>
public class VehicleMake : BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the vehicle manufacturer or brand.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets of sets the vehicle type that use this vehicle make.
    /// </summary>
    public virtual VehicleType Type { get; set; }

    /// <summary>
    /// Gets or sets the models list that use this vehicle make.
    /// </summary>
    public virtual ICollection<VehicleModel> Models { get; set; }
}
