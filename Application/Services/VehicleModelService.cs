namespace Application.Services;

using System.Net;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Results;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Service for managing vehicle models, including creating, updating,
/// retrieving, and deleting vehicle model data.
/// </summary>
public class VehicleModelService(AppDbContext context, IMapper mapper) : IVehicleModelService
{
    /// <summary>
    /// Retrieves all vehicle models.
    /// </summary>
    /// <returns>A result containing a collection of VehicleModelDto objects.</returns>
    public async Task<Result<ICollection<VehicleModelDto>>> GetAll()
    {
        var vehicleModels = await context.VehicleModels.ToListAsync();

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
        var vehicleModel = await context.VehicleModels.FirstOrDefaultAsync(vm => vm.Id == id);

        if (vehicleModel is null)
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

        context.VehicleModels.Add(vehicleModelToCreate);

        var isCreated = await context.SaveChangesAsync() > 0;

        return isCreated ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "The vehicle model was not created.");
    }

    /// <summary>
    /// Updates an existing vehicle model.
    /// </summary>
    /// <param name="updateVehicleModelDto">The DTO containing updated details of the vehicle model.</param>
    /// <returns>A success result if updated, or a failure result with the reason if update fails.</returns>
    public async Task<Result> Update(UpdateVehicleModelDto updateVehicleModelDto)
    {
        var vehicleModelToUpdate = await context.VehicleModels.FirstOrDefaultAsync(vm => vm.Id == updateVehicleModelDto.Id);

        if (vehicleModelToUpdate is null)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The vehicle model was not found.");
        }

        mapper.Map(updateVehicleModelDto, vehicleModelToUpdate);

        context.VehicleModels.Update(vehicleModelToUpdate);

        var isUpdated = await context.SaveChangesAsync() > 0;

        return isUpdated ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "The vehicle model was not updated.");
    }

    /// <summary>
    /// Deletes a vehicle model by its ID.
    /// </summary>
    /// <param name="id">The ID of the vehicle model to delete.</param>
    /// <returns>A success result if deleted, or a failure result with the reason if deletion fails.</returns>
    public async Task<Result> Delete(Guid id)
    {
        var vehicleModelToDelete = await context.VehicleModels.FirstOrDefaultAsync(vm => vm.Id == id);

        if (vehicleModelToDelete is null)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The vehicle model was not found");
        }

        context.VehicleModels.Remove(vehicleModelToDelete);

        var isDeleted = await context.SaveChangesAsync() > 0;

        return isDeleted ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "The vehicle model was not deleted.");
    }
}
