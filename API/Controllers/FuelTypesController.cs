namespace API.Controllers;

using Application.DTOs.Requests;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for managing fuel types, including retrieving, creating, updating, and deleting fuel types.
/// </summary>
/// /// <param name="service">The service for handling fuel type operations.</param>
/// <param name="createEngineTypeValidator">Validator for creating fuel types.</param>
/// <param name="updateEngineTypeValidator">Validator for updating fuel types.</param>
public class FuelTypesController(
    IFuelTypesService service,
    IValidator<CreateFuelTypeDto> createFuelTypeValidator,
    IValidator<UpdateFuelTypeDto> updateFuelTypeValdator)
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
    /// <param name="createFuelTypeDto">The data transfer object containing the details of the fuel type to create.</param>
    /// <returns>
    /// An HTTP response indicating whether the fuel type creation was successful or not.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateFuelTypeDto createFuelTypeDto)
    {
        var result = await createFuelTypeValidator.ValidateAsync(createFuelTypeDto);

        if (!result.IsValid)
        {
            return HandleResult(CreateModelNotValidResult(result.Errors));
        }

        return HandleResult(await service.Create(createFuelTypeDto));
    }

    /// <summary>
    /// Updates an existing fuel type.
    /// </summary>
    /// <param name="updateFuelTypeDto">The data transfer object containing the updated details of the fuel type.</param>
    /// <returns>
    /// An HTTP response indicating whether the fuel type update was successful or not.
    /// </returns>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateFuelTypeDto updateFuelTypeDto)
    {
        var result = await updateFuelTypeValdator.ValidateAsync(updateFuelTypeDto);

        if (!result.IsValid)
        {
            return HandleResult(CreateModelNotValidResult(result.Errors));
        }

        return HandleResult(await service.Update(updateFuelTypeDto));
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
