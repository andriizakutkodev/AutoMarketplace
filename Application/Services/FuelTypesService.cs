namespace Application.Services;

using System.Net;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Results;
using Persistence.Interfaces;

/// <summary>
/// Represents the service to work with fuel types.
/// </summary>
/// <param name="repository">The repository for accessing fuel type data.</param>
public class FuelTypesService(IFuelTypesRepository repository) : IFuelTypesService
{
    /// <summary>
    /// Retrieves all fuel types from the repository and maps them to data transfer objects (DTOs).
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result{T}"/> with a collection of <see cref="FuelTypeDto"/>.
    /// </returns>
    public async Task<Result<ICollection<FuelTypeDto>>> GetAll()
    {
        var fuelTypes = await repository.GetAll();

        var fuelTypeDtos = fuelTypes.Select(fuelType => new FuelTypeDto
        {
            Id = fuelType.Id,
            Name = fuelType.Name,
        }).ToList();

        return Result<ICollection<FuelTypeDto>>.Success(fuelTypeDtos);
    }

    /// <summary>
    /// Retrieves an fuel type by its unique identifier and maps it to a data transfer object (DTO).
    /// </summary>
    /// <param name="id">The unique identifier of the fuel type to retrieve.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result{T}"/> with the corresponding <see cref="FuelTypeDto"/>.
    /// If the fuel type is not found, it will return a failure result with an appropriate error message.
    public async Task<Result<FuelTypeDto>> GetById(Guid id)
    {
        var fuelType = await repository.GetById(id);

        var fuelTypeDto = new FuelTypeDto
        {
            Id = fuelType.Id,
            Name = fuelType.Name,
        };

        return Result<FuelTypeDto>.Success(fuelTypeDto);
    }

    /// <summary>
    /// Creates a new fuel type using the provided data transfer object (DTO).
    /// </summary>
    /// <param name="createFuelTypeDto">The data transfer object containing the details of the fuel type to create.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    public async Task<Result> Create(CreateFuelTypeDto createFuelTypeDto)
    {
        var fuelTypeToCreate = new FuelType
        {
            Id = Guid.NewGuid(),
            Name = createFuelTypeDto.Name,
        };

        var isCreated = await repository.Create(fuelTypeToCreate);

        return isCreated ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "Fuel type was not created. Try again.");
    }

    /// <summary>
    /// Updates an existing fuel type using the provided data transfer object (DTO).
    /// </summary>
    /// <param name="updateFuelTypeDto">The data transfer object containing the updated details of the fuel type.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    public async Task<Result> Update(UpdateFuelTypeDto updateFuelTypeDto)
    {
        var fuelTypeToUpdate = await repository.GetById(updateFuelTypeDto.Id);

        if (fuelTypeToUpdate == null)
        {
            return Result.Failure(HttpStatusCode.BadRequest, "Fuel type was not found to update.");
        }

        fuelTypeToUpdate.Name = updateFuelTypeDto.NewName;

        var isUpdated = await repository.Update(fuelTypeToUpdate);

        return isUpdated ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "Fuel type was not updated. Try again.");
    }

    /// <summary>
    /// Deletes an existing fuel type by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the fuel type to delete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    public async Task<Result> Delete(Guid id)
    {
        var fuelTypeToDelete = await repository.GetById(id);

        if (fuelTypeToDelete == null)
        {
            return Result.Failure(HttpStatusCode.BadGateway, "Fuel type was not found to delete.");
        }

        var isDeleted = await repository.Delete(fuelTypeToDelete);

        return isDeleted ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "Fuel type was not deleted. Try again");
    }
}
