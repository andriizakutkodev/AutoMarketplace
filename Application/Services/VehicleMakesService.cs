namespace Application.Services;

using System.Net;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Results;
using Persistence.Interfaces;

/// <summary>
/// Provides service operations for managing vehicle makes.
/// </summary>
/// <param name="vehicleMakesRepository">The repository for managing vehicle makes.</param>
/// <param name="vehicleTypesRepository">The repository for managing vehicle types.</param>
public class VehicleMakesService(IVehicleMakesRepository vehicleMakesRepository, IVehicleTypesRepository vehicleTypesRepository) : IVehicleMakesService
{
    /// <summary>
    /// Retrieves all vehicle makes.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a collection of vehicle make DTOs.
    /// </returns>
    public async Task<Result<ICollection<VehicleMakeDto>>> GetAll()
    {
        var vehicleMakes = await vehicleMakesRepository.GetAll();

        var vehicleMakeDtos = vehicleMakes.Select(vehicleMake => new VehicleMakeDto
        {
            Id = vehicleMake.Id,
            Name = vehicleMake.Name,
            Type = new TypeDto
            {
                Id = vehicleMake.Type.Id,
                Name = vehicleMake.Type.Name,
            },
        }).ToList();

        return Result<ICollection<VehicleMakeDto>>.Success(vehicleMakeDtos);
    }

    /// <summary>
    /// Retrieves a vehicle make by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle make.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the vehicle make DTO.
    /// If the vehicle make is not found, a failure result is returned.
    /// </returns>
    public async Task<Result<VehicleMakeDto>> GetById(Guid id)
    {
        var vehicelMake = await vehicleMakesRepository.GetById(id);

        if (vehicelMake == null)
        {
            return Result<VehicleMakeDto>.Failure(HttpStatusCode.NotFound, "The vehicle make was not found. Try again");
        }

        var vehicleMakeDto = new VehicleMakeDto
        {
            Id = vehicelMake.Id,
            Name = vehicelMake.Name,
            Type = new TypeDto
            {
                Id = vehicelMake.Type.Id,
                Name = vehicelMake.Type.Name,
            },
        };

        return Result<VehicleMakeDto>.Success(vehicleMakeDto);
    }

    /// <summary>
    /// Creates a new vehicle make.
    /// </summary>
    /// <param name="createVehicleMakeDto">The DTO containing the details of the vehicle make to create.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result indicates whether the creation was successful.
    /// If the associated vehicle type is not found, a failure result is returned.
    /// </returns>
    public async Task<Result> Create(CreateVehicleMakeDto createVehicleMakeDto)
    {
        var vehicleType = await vehicleTypesRepository.GetById(createVehicleMakeDto.VehicleTypeId);

        if (vehicleType == null)
        {
            return Result.Failure(HttpStatusCode.NotFound, $"The vehicle type with {createVehicleMakeDto.VehicleTypeId} was not found. Try again.");
        }

        var vehicleMakeToCreate = new VehicleMake
        {
            Id = Guid.NewGuid(),
            Name = createVehicleMakeDto.Name,
            Type = vehicleType,
        };

        var isCreated = await vehicleMakesRepository.Create(vehicleMakeToCreate);

        return isCreated ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "The vehicle type was not created. Try again");
    }

    /// <summary>
    /// Updates an existing vehicle make.
    /// </summary>
    /// <param name="updateVehicleMakeDto">The DTO containing the updated details of the vehicle make.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result indicates whether the update was successful.
    /// If the vehicle make or the associated vehicle type is not found, a failure result is returned.
    /// </returns>
    public async Task<Result> Update(UpdateVehicleMakeDto updateVehicleMakeDto)
    {
        var vehicleMakeToUpdate = await vehicleMakesRepository.GetById(updateVehicleMakeDto.Id);

        if (vehicleMakeToUpdate == null)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The vehicle make to update was not found. Try again.");
        }

        var vehicleTypeToUpdate = await vehicleTypesRepository.GetById(updateVehicleMakeDto.Type.Id);

        if (vehicleTypeToUpdate == null)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The vehicle type to update was not found. Try again.");
        }

        vehicleTypeToUpdate.Name = updateVehicleMakeDto.Type.Name;

        vehicleMakeToUpdate.Name = updateVehicleMakeDto.Name;
        vehicleMakeToUpdate.Type = vehicleTypeToUpdate;

        var isUpdated = await vehicleMakesRepository.Update(vehicleMakeToUpdate);

        return isUpdated ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "The vehicle make was not updated. Try again.");
    }

    /// <summary>
    /// Deletes a vehicle make by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle make to delete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result indicates whether the deletion was successful.
    /// If the vehicle make is not found, a failure result is returned.
    /// </returns>
    public async Task<Result> Delete(Guid id)
    {
        var vehicleMakeToDelete = await vehicleMakesRepository.GetById(id);

        if (vehicleMakeToDelete == null)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The vehicle make to delete was not found");
        }

        var isDeleted = await vehicleMakesRepository.Delete(vehicleMakeToDelete);

        return isDeleted ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "The vehicle make was not deleted. Try again");
    }
}
