namespace Application.Services;

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Results;
using Persistence.Interfaces;

/// <summary>
/// Provides a generic service for managing types that inherit from <see cref="GenericType"/>.
/// </summary>
/// <typeparam name="TRepository">
/// The type of the repository implementing <see cref="IGenericRepository{TEntity}"/>.
/// </typeparam>
/// <typeparam name="TEntity">
/// The entity type that must inherit from <see cref="GenericType"/>.
/// </typeparam>
public class TypesService<TRepository, TEntity> : ITypesService
    where TRepository : IGenericRepository<TEntity>
    where TEntity : GenericType
{
    private readonly TRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="TypesService{TRepository, TEntity}"/> class.
    /// </summary>
    /// <param name="repository">The repository for accessing type data.</param>
    public TypesService(TRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Retrieves all types from the repository and maps them to data transfer objects (DTOs).
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result{T}"/> with a collection of <see cref="TypeDto"/>.
    /// </returns>
    public virtual async Task<Result<ICollection<TypeDto>>> GetAll()
    {
        var types = await _repository.GetAll();

        var typeDtos = types.Select(type => new TypeDto
        {
            Id = type.Id,
            Name = type.Name,
        }).ToList();

        return Result<ICollection<TypeDto>>.Success(typeDtos);
    }

    /// <summary>
    /// Retrieves a type by its unique identifier and maps it to a data transfer object (DTO).
    /// </summary>
    /// <param name="id">The unique identifier of the type to retrieve.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result{T}"/> with the corresponding <see cref="TypeDto"/>.
    /// If the type is not found, it will return a failure result with an appropriate error message.
    public virtual async Task<Result<TypeDto>> GetById(Guid id)
    {
        var type = await _repository.GetById(id);

        var typeDto = new TypeDto
        {
            Id = type.Id,
            Name = type.Name,
        };

        return Result<TypeDto>.Success(typeDto);
    }

    /// <summary>
    /// Creates a new type using the provided data transfer object (DTO).
    /// </summary>
    /// <param name="createTypeDto">The data transfer object containing the details of the type to create.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    public virtual async Task<Result> Create(CreateTypeDto createTypeDto)
    {
        var typeToCreate = Activator.CreateInstance(typeof(TEntity)) as GenericType;

        if (typeToCreate == null)
        {
            return Result.Failure(HttpStatusCode.BadRequest, $"Unable to create instance of {typeof(TEntity).Name}");
        }

        typeToCreate.Id = Guid.NewGuid();
        typeToCreate.Name = createTypeDto.Name;

        var isCreated = await _repository.Create((TEntity)typeToCreate);

        return isCreated ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "Type was not created. Try again.");
    }

    /// <summary>
    /// Updates an existing type using the provided data transfer object (DTO).
    /// </summary>
    /// <param name="updateTypeDto">The data transfer object containing the updated details of the type.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    public virtual async Task<Result> Update(UpdateTypeDto updateTypeDto)
    {
        var typeToUpdate = await _repository.GetById(updateTypeDto.Id);

        if (typeToUpdate == null)
        {
            return Result.Failure(HttpStatusCode.BadRequest, "Type was not found to update.");
        }

        typeToUpdate.Name = updateTypeDto.Name;

        var isUpdated = await _repository.Update(typeToUpdate);

        return isUpdated ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "Type was not updated. Try again.");
    }

    /// <summary>
    /// Deletes an existing type by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the type to delete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="Result"/> indicating the success or failure of the operation.
    /// </returns>
    public virtual async Task<Result> Delete(Guid id)
    {
        var typeToDelete = await _repository.GetById(id);

        if (typeToDelete == null)
        {
            return Result.Failure(HttpStatusCode.BadGateway, "Type was not found to delete.");
        }

        var isDeleted = await _repository.Delete(typeToDelete);

        return isDeleted ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "Type was not deleted. Try again");
    }
}
