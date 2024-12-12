namespace Application.Interfaces;

using Application.DTOs;
using Infrastructure.Results;

/// <summary>
/// Service interface for managing vehicle models.
/// </summary>
public interface IVehicleModelsService
{
    /// <summary>
    /// Retrieves all vehicle models.
    /// </summary>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The task result contains a collection of <see cref="VehicleModelDto"/>.
    /// </returns>
    Task<Result<ICollection<VehicleModelDto>>> GetAll();

    /// <summary>
    /// Retrieves a vehicle model by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle model.</param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The task result contains the <see cref="VehicleModelDto"/> if found.
    /// </returns>
    Task<Result<VehicleModelDto>> GetById(Guid id);

    /// <summary>
    /// Creates a new vehicle model.
    /// </summary>
    /// <param name="createVehicleModelDto">The data transfer object containing the details of the vehicle model to create.</param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The task result indicates whether the creation was successful.
    /// </returns>
    Task<Result> Create(CreateVehicleModelDto createVehicleModelDto);

    /// <summary>
    /// Updates an existing vehicle model.
    /// </summary>
    /// <param name="updateVehicleModelDto">The data transfer object containing the updated details of the vehicle model.</param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The task result indicates whether the update was successful.
    /// </returns>
    Task<Result> Update(UpdateVehicleModelDto updateVehicleModelDto);

    /// <summary>
    /// Deletes a vehicle model by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle model to delete.</param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The task result indicates whether the deletion was successful.
    /// </returns>
    Task<Result> Delete(Guid id);
}
