namespace Persistence.Repositories;

using Domain.Entities;
using Infrastructure.Data;
using Persistence.Interfaces;

/// <summary>
/// Implements the <see cref="IVehiclesRepository"/> interface to manage vehicle data in the data store.
/// Provides functionality for adding, retrieving, updating, and deleting vehicle records.
/// </summary>
public class VehiclesRepository(AppDbContext context) : GenericRepository<Vehicle>(context), IVehiclesRepository
{
}
