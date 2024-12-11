namespace Application.Interfaces;

using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Infrastructure.Results;

/// <summary>
/// Defines the service operations for managing vehicle makes.
/// </summary>
public interface IVehicleMakesService
{
    /// <summary>
    /// Retrieves all vehicle makes.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a collection of vehicle make DTOs.
    /// </returns>
    Task<Result<ICollection<VehicleMakeDto>>> GetAll();

    /// <summary>
    /// Retrieves a vehicle make by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle make.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the vehicle make DTO.
    /// </returns>
    Task<Result<VehicleMakeDto>> GetById(Guid id);

    /// <summary>
    /// Creates a new vehicle make.
    /// </summary>
    /// <param name="createVehicleMakeDto">The data transfer object containing the details of the vehicle make to create.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result indicates whether the creation was successful.
    /// </returns>
    Task<Result> Create(CreateVehicleMakeDto createVehicleMakeDto);

    /// <summary>
    /// Updates an existing vehicle make.
    /// </summary>
    /// <param name="updateVehicleMakeDto">The data transfer object containing the updated details of the vehicle make.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result indicates whether the update was successful.
    /// </returns>
    Task<Result> Update(UpdateVehicleMakeDto updateVehicleMakeDto);

    /// <summary>
    /// Deletes a vehicle make by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle make to delete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result indicates whether the deletion was successful.
    /// </returns>
    Task<Result> Delete(Guid id);
}
