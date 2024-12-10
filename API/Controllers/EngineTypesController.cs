namespace API.Controllers;

using Application.DTOs.Requests;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for managing engine types, including retrieving, creating, updating, and deleting engine types.
/// </summary>
/// /// <param name="service">The service for handling engine type operations.</param>
/// <param name="createEngineTypeValidator">Validator for creating engine types.</param>
/// <param name="updateEngineTypeValidator">Validator for updating engine types.</param>
public class EngineTypesController(
    IEngineTypesService service,
    IValidator<CreateEngineTypeDto> createEngineTypeValidator,
    IValidator<UpdateEngineTypeDto> updateEngineTypeValidator)
    : BaseAPIController
{
    /// <summary>
    /// Retrieves all engine types.
    /// </summary>
    /// <returns>
    /// An HTTP response containing a collection of engine types, or an error if the retrieval fails.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return HandleResult(await service.GetAll());
    }

    /// <summary>
    /// Retrieves an engine type by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the engine type to retrieve.</param>
    /// <returns>
    /// An HTTP response containing the engine type, or an error if the retrieval fails.
    /// </returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return HandleResult(await service.GetById(id));
    }

    /// <summary>
    /// Creates a new engine type.
    /// </summary>
    /// <param name="createEngineTypeDto">The data transfer object containing the details of the engine type to create.</param>
    /// <returns>
    /// An HTTP response indicating whether the engine type creation was successful or not.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateEngineTypeDto createEngineTypeDto)
    {
        var result = await createEngineTypeValidator.ValidateAsync(createEngineTypeDto);

        if (!result.IsValid)
        {
            return HandleResult(CreateModelNotValidResult(result.Errors));
        }

        return HandleResult(await service.Create(createEngineTypeDto));
    }

    /// <summary>
    /// Updates an existing engine type.
    /// </summary>
    /// <param name="updateEngineTypeDto">The data transfer object containing the updated details of the engine type.</param>
    /// <returns>
    /// An HTTP response indicating whether the engine type update was successful or not.
    /// </returns>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateEngineTypeDto updateEngineTypeDto)
    {
        var result = await updateEngineTypeValidator.ValidateAsync(updateEngineTypeDto);

        if (!result.IsValid)
        {
            return HandleResult(CreateModelNotValidResult(result.Errors));
        }

        return HandleResult(await service.Update(updateEngineTypeDto));
    }

    /// <summary>
    /// Deletes an engine type by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the engine type to delete.</param>
    /// <returns>
    /// An HTTP response indicating whether the engine type deletion was successful or not.
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return HandleResult(await service.Delete(id));
    }
}
