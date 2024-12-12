namespace Persistence.Interfaces;

using Domain.Entities;

/// <summary>
/// Represents a repository interface for managing <see cref="VehicleModel"/> entities.
/// Extends the generic repository interface with methods specific to <see cref="VehicleModel"/>.
/// </summary>
public interface IVehicleModelsRepository : IGenericRepository<VehicleModel>
{
}
