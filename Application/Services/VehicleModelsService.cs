namespace Application.Services;

using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Results;
using Persistence.Interfaces;

/// <summary>
/// Service for managing vehicle models, including creating, updating,
/// retrieving, and deleting vehicle model data.
/// </summary>
public class VehicleModelsService(IVehicleModelsRepository repository) : IVehicleModelsService
{
    /// <summary>
    /// Retrieves all vehicle models.
    /// </summary>
    /// <returns>A result containing a collection of VehicleModelDto objects.</returns>
    public async Task<Result<ICollection<VehicleModelDto>>> GetAll()
    {
        var vehicleModels = await repository.GetAll();

        var vehicleModelDtos = vehicleModels.Select(vehicleModel => new VehicleModelDto
        {
            Id = vehicleModel.Id,
            Name = vehicleModel.Name,
            EngineCapacity = vehicleModel.EngineCapacity,
            Make = vehicleModel.Make,
            EngineType = vehicleModel.EngineType,
            ReleaseDate = vehicleModel.ReleaseDate,
        }).ToList();

        return Result<ICollection<VehicleModelDto>>.Success(vehicleModelDtos);
    }

    /// <summary>
    /// Retrieves a vehicle model by its ID.
    /// </summary>
    /// <param name="id">The ID of the vehicle model.</param>
    /// <returns>A result containing the VehicleModelDto object if found, or a failure result if not found.</returns>
    public async Task<Result<VehicleModelDto>> GetById(Guid id)
    {
        var vehicleModel = await repository.GetById(id);

        if (vehicleModel is null)
        {
            return Result<VehicleModelDto>.Failure(HttpStatusCode.NotFound, "The vehicle model was not found.");
        }

        var vehicleModelDto = new VehicleModelDto
        {
            Id = vehicleModel.Id,
            Name = vehicleModel.Name,
            EngineCapacity = vehicleModel.EngineCapacity,
            Make = vehicleModel.Make,
            EngineType = vehicleModel.EngineType,
            ReleaseDate = vehicleModel.ReleaseDate,
        };

        return Result<VehicleModelDto>.Success(vehicleModelDto);
    }

    /// <summary>
    /// Creates a new vehicle model.
    /// </summary>
    /// <param name="createVehicleModelDto">The DTO containing details of the vehicle model to create.</param>
    /// <returns>A success result if created, or a failure result with the reason if creation fails.</returns>
    public async Task<Result> Create(CreateVehicleModelDto createVehicleModelDto)
    {
        var vehicleModelToCreate = new VehicleModel
        {
            Id = Guid.NewGuid(),
            Name = createVehicleModelDto.Name,
            EngineCapacity = createVehicleModelDto.EngineCapacity,
            ReleaseDate = createVehicleModelDto.ReleaseDate,
            Make = createVehicleModelDto.Make,
            EngineType = createVehicleModelDto.EngineType,
        };

        var isCreated = await repository.Create(vehicleModelToCreate);

        return isCreated ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "The vehicle model was not created.");
    }

    /// <summary>
    /// Updates an existing vehicle model.
    /// </summary>
    /// <param name="updateVehicleModelDto">The DTO containing updated details of the vehicle model.</param>
    /// <returns>A success result if updated, or a failure result with the reason if update fails.</returns>
    public async Task<Result> Update(UpdateVehicleModelDto updateVehicleModelDto)
    {
        var vehicleModelToUpdate = await repository.GetById(updateVehicleModelDto.Id);

        if (vehicleModelToUpdate is null)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The vehicle model was not found.");
        }

        vehicleModelToUpdate.Name = updateVehicleModelDto.Name;
        vehicleModelToUpdate.EngineCapacity = updateVehicleModelDto.EngineCapacity;
        vehicleModelToUpdate.ReleaseDate = updateVehicleModelDto.ReleaseDate;
        vehicleModelToUpdate.Make = updateVehicleModelDto.Make;
        vehicleModelToUpdate.EngineType = updateVehicleModelDto.EngineType;

        var isUpdated = await repository.Update(vehicleModelToUpdate);

        return isUpdated ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "The vehicle model was not updated.");
    }

    /// <summary>
    /// Deletes a vehicle model by its ID.
    /// </summary>
    /// <param name="id">The ID of the vehicle model to delete.</param>
    /// <returns>A success result if deleted, or a failure result with the reason if deletion fails.</returns>
    public async Task<Result> Delete(Guid id)
    {
        var vehicleModelToDelete = await repository.GetById(id);

        if (vehicleModelToDelete is null)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The vehicle model was not found");
        }

        var isDeleted = await repository.Delete(vehicleModelToDelete);

        return isDeleted ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "The vehicle model was not deleted.");
    }
}
