namespace API.Controllers;

using Application.DTOs.Requests;
using Application.Interfaces.Types;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for managing vehicle types, including retrieving, creating, updating, and deleting vehicle types.
/// </summary>
/// /// <param name="service">The service for handling vehicle type operations.</param>
/// <param name="createTypeValidator">Validator for creating vehicle types.</param>
/// <param name="updateTypeValdator">Validator for updating vehicle types.</param>
public class VehicleTypesController(
    IVehicleTypesService service,
    IValidator<CreateTypeDto> createTypeValidator,
    IValidator<UpdateTypeDto> updateTypeValdator)
    : BaseAPIController
{
    /// <summary>
    /// Retrieves all vehicle types.
    /// </summary>
    /// <returns>
    /// An HTTP response containing a collection of vehicle types, or an error if the retrieval fails.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return HandleResult(await service.GetAll());
    }

    /// <summary>
    /// Retrieves an vehicle type by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle type to retrieve.</param>
    /// <returns>
    /// An HTTP response containing the vehicle type, or an error if the retrieval fails.
    /// </returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return HandleResult(await service.GetById(id));
    }

    /// <summary>
    /// Creates a new vehicle type.
    /// </summary>
    /// <param name="createTypeDto">The data transfer object containing the details of the vehicle type to create.</param>
    /// <returns>
    /// An HTTP response indicating whether the vehicle type creation was successful or not.
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
    /// Updates an existing vehicle type.
    /// </summary>
    /// <param name="updateTypeDto">The data transfer object containing the updated details of the vehicle type.</param>
    /// <returns>
    /// An HTTP response indicating whether the vehicle type update was successful or not.
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
    /// Deletes an vehicle type by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle type to delete.</param>
    /// <returns>
    /// An HTTP response indicating whether the vehicle type deletion was successful or not.
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return HandleResult(await service.Delete(id));
    }
}
