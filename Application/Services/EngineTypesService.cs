namespace Application.Services;

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Results;
using Persistence.Interfaces;

/// <summary>
/// Represents the service to work with engine types.
/// </summary>
/// <param name="repository">The repository for accessing engine type data.</param>
public class EngineTypesService(IEngineTypesRepository repository) : IEngineTypesService
{
    /// <summary>
    /// Retrieves all engine types from the repository and maps them to data transfer objects (DTOs).
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result{T}"/> with a collection of <see cref="EngineTypeDto"/>.
    /// </returns>
    public async Task<Result<ICollection<EngineTypeDto>>> GetAll()
    {
        var engineTypes = await repository.GetAll();

        var engineTypeDtos = engineTypes.Select(engineType => new EngineTypeDto
        {
            Id = engineType.Id,
            Name = engineType.Name,
        }).ToList();

        return Result<ICollection<EngineTypeDto>>.Success(engineTypeDtos);
    }

    /// <summary>
    /// Retrieves an engine type by its unique identifier and maps it to a data transfer object (DTO).
    /// </summary>
    /// <param name="id">The unique identifier of the engine type to retrieve.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result{T}"/> with the corresponding <see cref="EngineTypeDto"/>.
    /// If the engine type is not found, it will return a failure result with an appropriate error message.
    /// </returns>
    public async Task<Result<EngineTypeDto>> GetById(Guid id)
    {
        var engineType = await repository.GetById(id);

        var engineTypeDto = new EngineTypeDto
        {
            Id = engineType.Id,
            Name = engineType.Name,
        };

        return Result<EngineTypeDto>.Success(engineTypeDto);
    }

    /// <summary>
    /// Creates a new engine type using the provided data transfer object (DTO).
    /// </summary>
    /// <param name="createEngineTypeDto">The data transfer object containing the details of the engine type to create.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    public async Task<Result> Create(CreateEngineTypeDto createEngineTypeDto)
    {
        var engineTypeToCreate = new EngineType
        {
            Id = Guid.NewGuid(),
            Name = createEngineTypeDto.Name,
        };

        var isCreated = await repository.Create(engineTypeToCreate);

        return isCreated ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "Engine type was not created. Try again.");
    }

    /// <summary>
    /// Updates an existing engine type using the provided data transfer object (DTO).
    /// </summary>
    /// <param name="updateEngineTypeDto">The data transfer object containing the updated details of the engine type.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    public async Task<Result> Update(UpdateEngineTypeDto updateEngineTypeDto)
    {
        var engineToUpdate = await repository.GetById(updateEngineTypeDto.Id);

        if (engineToUpdate == null)
        {
            return Result.Failure(HttpStatusCode.BadRequest, "Engine type was not found to update.");
        }

        engineToUpdate.Name = updateEngineTypeDto.NewName;

        var isUpdated = await repository.Update(engineToUpdate);

        return isUpdated ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "Engine type was not updated. Try again.");
    }

    /// <summary>
    /// Deletes an existing engine type by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the engine type to delete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    public async Task<Result> Delete(Guid id)
    {
        var engineToDelete = await repository.GetById(id);

        if (engineToDelete == null)
        {
            return Result.Failure(HttpStatusCode.BadGateway, "Engine type was not found to delete.");
        }

        var isDeleted = await repository.Delete(engineToDelete);

        return isDeleted ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "Engine type was not deleted. Try again");
    }
}
