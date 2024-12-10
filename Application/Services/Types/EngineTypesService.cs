﻿namespace Application.Services.Types;

using Application.Interfaces.Types;
using Domain.Entities;
using Persistence.Interfaces;

/// <summary>
/// Represents the service to work with engine types.
/// </summary>
public class EngineTypesService : GenericTypesService<IEngineTypesRepository, EngineType>, IEngineTypesService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EngineTypesService"/> class.
    /// </summary>
    /// <param name="repository">The repository for accessing fuel type data.</param>
    public EngineTypesService(IEngineTypesRepository repository)
        : base(repository)
    {
    }
}