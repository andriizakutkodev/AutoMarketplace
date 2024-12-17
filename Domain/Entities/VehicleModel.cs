namespace Domain.Entities;

using Domain.Enums;

/// <summary>
/// Represents a specific model of a vehicle.
/// </summary>
public class VehicleModel : BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the vehicle model.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the engine capacity info for model.
    /// </summary>
    public int EngineCapacity { get; set; }

    /// <summary>
    /// Gets or sets the make (manufacturer) of the vehicle model.
    /// </summary>
    public virtual VehicleMake Make { get; set; }

    /// <summary>
    /// Gets or sets the vehicle type of the vehicle.
    /// </summary>
    public virtual VehicleType VehicleType { get; set; }

    /// <summary>
    /// Gets or sets the engine type of the vehicle.
    /// </summary>
    public virtual EngineType EngineType { get; set; }
}
