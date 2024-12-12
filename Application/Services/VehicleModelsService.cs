namespace Application.Services;

using System.Net;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Results;
using Persistence.Interfaces;

/// <summary>
/// Service for managing vehicle models, including creating, updating,
/// retrieving, and deleting vehicle model data.
/// </summary>
public class VehicleModelsService(
    IVehicleModelsRepository repository,
    IMapper mapper) : IVehicleModelsService
{
    /// <summary>
    /// Retrieves all vehicle models.
    /// </summary>
    /// <returns>A result containing a collection of VehicleModelDto objects.</returns>
    public async Task<Result<ICollection<VehicleModelDto>>> GetAll()
    {
        var vehicleModels = await repository.GetAll();

        var vehicleModelDtos = vehicleModels.Select(mapper.Map<VehicleModelDto>).ToList();

        return Result<ICollection<VehicleModelDto>>.Success(vehicleModelDtos);
    }

    /// <summary>
    /// Retrieves a vehicle model by its ID.
    /// </summary>
    /// <param name="id">The ID of the vehicle model.</param>
    /// <returns>A result containing the VehicleModelDto object if found, or a failure result if not found.</returns>
    public async Task<Result<VehicleModelDto>> GetById(Guid id)
    {
        var (exists, vehicleModel) = await repository.IsRecordExist(id);

        if (!exists)
        {
            return Result<VehicleModelDto>.Failure(HttpStatusCode.NotFound, "The vehicle model was not found.");
        }

        var vehicleModelDto = mapper.Map<VehicleModelDto>(vehicleModel);

        return Result<VehicleModelDto>.Success(vehicleModelDto);
    }

    /// <summary>
    /// Creates a new vehicle model.
    /// </summary>
    /// <param name="createVehicleModelDto">The DTO containing details of the vehicle model to create.</param>
    /// <returns>A success result if created, or a failure result with the reason if creation fails.</returns>
    public async Task<Result> Create(CreateVehicleModelDto createVehicleModelDto)
    {
        var vehicleModelToCreate = mapper.Map<VehicleModel>(createVehicleModelDto);

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
        var (exists, vehicleModelToUpdate) = await repository.IsRecordExist(updateVehicleModelDto.Id);

        if (!exists)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The vehicle model was not found.");
        }

        mapper.Map(updateVehicleModelDto, vehicleModelToUpdate);

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
        var (exists, vehicleModelToDelete) = await repository.IsRecordExist(id);

        if (!exists)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The vehicle model was not found");
        }

        var isDeleted = await repository.Delete(vehicleModelToDelete);

        return isDeleted ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "The vehicle model was not deleted.");
    }
}
