namespace Application.Interfaces.Types;

using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Infrastructure.Results;

/// <summary>
/// Defines the contract for a service that manages types.
/// </summary>
public interface IGenericTypesService
{
    /// <summary>
    /// Retrieves all types as a collection of data transfer objects (DTOs).
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result{T}"/> with a collection of <see cref="TypeDto"/>.
    /// </returns>
    Task<Result<ICollection<TypeDto>>> GetAll();

    /// <summary>
    /// Retrieves a type by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the type.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result{T}"/> with the <see cref="TypeDto"/> for the specified ID.
    /// </returns>
    Task<Result<TypeDto>> GetById(Guid id);

    /// <summary>
    /// Creates a new type.
    /// </summary>
    /// <param name="createTypeDto">The data transfer object containing the details of the type to create.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    Task<Result> Create(CreateTypeDto createTypeDto);

    /// <summary>
    /// Updates an existing type.
    /// </summary>
    /// <param name="updateTypeDto">The data transfer object containing the updated details of the type.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    Task<Result> Update(UpdateTypeDto updateTypeDto);

    /// <summary>
    /// Deletes an existing type.
    /// </summary>
    /// <param name="id">The identifier of the type to delete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    Task<Result> Delete(Guid id);
}
