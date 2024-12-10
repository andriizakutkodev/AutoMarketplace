namespace Application.Services.Types;

using Application.Interfaces.Types;
using Domain.Entities;
using Persistence.Interfaces;

/// <summary>
/// Represents the service to work with vehicle types.
/// </summary>
public class VehicleTypesService : GenericTypesService<IVehicleTypesRepository, VehicleType>, IVehicleTypesService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VehicleTypesService"/> class.
    /// </summary>
    /// <param name="repository">The repository for accessing vehicle type data.</param>
    public VehicleTypesService(IVehicleTypesRepository repository)
        : base(repository)
    {
    }
}
