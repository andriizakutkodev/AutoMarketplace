namespace Application.Interfaces;

using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Infrastructure.Results;

/// <summary>
/// Defines the contract for a service that manages engine types.
/// </summary>
public interface IEngineTypesService
{
    /// <summary>
    /// Retrieves all engine types as a collection of data transfer objects (DTOs).
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result{T}"/> with a collection of <see cref="EngineTypeDto"/>.
    /// </returns>
    Task<Result<ICollection<EngineTypeDto>>> GetAll();

    /// <summary>
    /// Retrieves an engine type by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the engine type.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result{T}"/> with the <see cref="EngineTypeDto"/> for the specified ID.
    /// </returns>
    Task<Result<EngineTypeDto>> GetById(Guid id);

    /// <summary>
    /// Creates a new engine type.
    /// </summary>
    /// <param name="createEngineTypeDto">The data transfer object containing the details of the engine type to create.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    Task<Result> Create(CreateEngineTypeDto createEngineTypeDto);

    /// <summary>
    /// Updates an existing engine type.
    /// </summary>
    /// <param name="updateEngineTypeDto">The data transfer object containing the updated details of the engine type.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    Task<Result> Update(UpdateEngineTypeDto updateEngineTypeDto);

    /// <summary>
    /// Deletes an existing engine type.
    /// </summary>
    /// <param name="id">The identifier of the engine type to delete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    Task<Result> Delete(Guid id);
}
