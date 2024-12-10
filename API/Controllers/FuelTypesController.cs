namespace API.Controllers;

using Application.DTOs.Requests;
using Application.Interfaces.Types;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for managing fuel types, including retrieving, creating, updating, and deleting fuel types.
/// </summary>
/// /// <param name="service">The service for handling fuel type operations.</param>
/// <param name="createTypeValidator">Validator for creating fuel types.</param>
/// <param name="updateTypeValdator">Validator for updating fuel types.</param>
public class FuelTypesController(
    IFuelTypesService service,
    IValidator<CreateTypeDto> createTypeValidator,
    IValidator<UpdateTypeDto> updateTypeValdator)
    : BaseAPIController
{
    /// <summary>
    /// Retrieves all fuel types.
    /// </summary>
    /// <returns>
    /// An HTTP response containing a collection of fuel types, or an error if the retrieval fails.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return HandleResult(await service.GetAll());
    }

    /// <summary>
    /// Retrieves an fuel type by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the fuel type to retrieve.</param>
    /// <returns>
    /// An HTTP response containing the fuel type, or an error if the retrieval fails.
    /// </returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return HandleResult(await service.GetById(id));
    }

    /// <summary>
    /// Creates a new fuel type.
    /// </summary>
    /// <param name="createTypeDto">The data transfer object containing the details of the fuel type to create.</param>
    /// <returns>
    /// An HTTP response indicating whether the fuel type creation was successful or not.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateTypeDto createTypeDto)
    {
        var result = await createTypeValidator.ValidateAsync(createTypeDto);

        if (!result.IsValid)
        {
            return HandleResult(CreateModelNotValidResult(result.Errors));
        }

        return HandleResult(await service.Create(createTypeDto));
    }

    /// <summary>
    /// Updates an existing fuel type.
    /// </summary>
    /// <param name="updateTypeDto">The data transfer object containing the updated details of the fuel type.</param>
    /// <returns>
    /// An HTTP response indicating whether the fuel type update was successful or not.
    /// </returns>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateTypeDto updateTypeDto)
    {
        var result = await updateTypeValdator.ValidateAsync(updateTypeDto);

        if (!result.IsValid)
        {
            return HandleResult(CreateModelNotValidResult(result.Errors));
        }

        return HandleResult(await service.Update(updateTypeDto));
    }

    /// <summary>
    /// Deletes an fuel type by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the fuel type to delete.</param>
    /// <returns>
    /// An HTTP response indicating whether the fuel type deletion was successful or not.
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return HandleResult(await service.Delete(id));
    }
}
