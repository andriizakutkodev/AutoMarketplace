namespace Persistence.Interfaces;

using Domain.Entities;

/// <summary>
/// Represents a repository interface for managing <see cref="FuelType"/> entities.
/// Extends the generic repository interface with methods specific to <see cref="FuelType"/>.
/// </summary>
public interface IFuelTypesRepository : IGenericRepository<FuelType>
{
}
