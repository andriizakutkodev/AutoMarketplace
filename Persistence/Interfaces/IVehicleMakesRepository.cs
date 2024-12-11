namespace Persistence.Interfaces;

using Domain.Entities;

/// <summary>
/// Represents a repository interface for managing <see cref="VehicleMake"/> entities.
/// Extends the generic repository interface with methods specific to <see cref="VehicleMake"/>.
/// </summary>
public interface IVehicleMakesRepository : IGenericRepository<VehicleMake>
{
}
