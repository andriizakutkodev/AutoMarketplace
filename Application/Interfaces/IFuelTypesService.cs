namespace Application.Interfaces;

using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Infrastructure.Results;

/// <summary>
/// Defines the contract for a service that manages fuel types.
/// </summary>
public interface IFuelTypesService
{
    /// <summary>
    /// Retrieves all fuel types as a collection of data transfer objects (DTOs).
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result{T}"/> with a collection of <see cref="FuelTypeDto"/>.
    /// </returns>
    Task<Result<ICollection<FuelTypeDto>>> GetAll();

    /// <summary>
    /// Retrieves an fuel type by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the fuel type.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result{T}"/> with the <see cref="FuelTypeDto"/> for the specified ID.
    /// </returns>
    Task<Result<FuelTypeDto>> GetById(Guid id);

    /// <summary>
    /// Creates a new fuel type.
    /// </summary>
    /// <param name="createFuelTypeDto">The data transfer object containing the details of the fuel type to create.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    Task<Result> Create(CreateFuelTypeDto createFuelTypeDto);

    /// <summary>
    /// Updates an existing fuel type.
    /// </summary>
    /// <param name="updateFuelTypeDto">The data transfer object containing the updated details of the fuel type.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    Task<Result> Update(UpdateFuelTypeDto updateFuelTypeDto);

    /// <summary>
    /// Deletes an existing fuel type.
    /// </summary>
    /// <param name="id">The identifier of the fuel type to delete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    Task<Result> Delete(Guid id);
}
