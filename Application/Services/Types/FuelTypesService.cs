namespace Application.Services.Types;

using Application.Interfaces.Types;

using Domain.Entities;

using Persistence.Interfaces;

/// <summary>
/// Represents the service to work with fuel types.
/// </summary>
public class FuelTypesService : GenericTypesService<IFuelTypesRepository, FuelType>, IFuelTypesService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FuelTypesService"/> class.
    /// </summary>
    /// <param name="repository">The repository for accessing fuel type data.</param>
    public FuelTypesService(IFuelTypesRepository repository)
        : base(repository)
    {
    }
}
