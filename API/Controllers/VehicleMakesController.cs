namespace API.Controllers;

using Application.DTOs.Requests;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Handles HTTP requests related to vehicle makes.
/// </summary>
/// <param name="service">The service for managing vehicle makes.</param>
/// <param name="createVehicleMakeValidator">The validator for creating vehicle make DTOs.</param>
/// <param name="updateVehicleMakeValidator">The validator for updating vehicle make DTOs.</param>
public class VehicleMakesController(
    IVehicleMakesService service,
    IValidator<CreateVehicleMakeDto> createVehicleMakeValidator,
    IValidator<UpdateVehicleMakeDto> updateVehicleMakeValidator) : BaseAPIController
{
    /// <summary>
    /// Retrieves all vehicle makes.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an HTTP response with a list of vehicle makes.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return HandleResult(await service.GetAll());
    }

    /// <summary>
    /// Retrieves a vehicle make by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle make.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an HTTP response with the vehicle make data.
    /// If the vehicle make is not found, an appropriate HTTP error response is returned.
    /// </returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return HandleResult(await service.GetById(id));
    }

    /// <summary>
    /// Creates a new vehicle make.
    /// </summary>
    /// <param name="createVehicleMakeDto">The DTO containing the details of the vehicle make to create.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an HTTP response indicating whether the creation was successful.
    /// If validation fails, an appropriate HTTP error response is returned.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateVehicleMakeDto createVehicleMakeDto)
    {
        var result = await createVehicleMakeValidator.ValidateAsync(createVehicleMakeDto);

        if (!result.IsValid)
        {
            return HandleResult(CreateModelNotValidResult(result.Errors));
        }

        return HandleResult(await service.Create(createVehicleMakeDto));
    }

    /// <summary>
    /// Updates an existing vehicle make.
    /// </summary>
    /// <param name="updateVehicleMakeDto">The DTO containing the updated details of the vehicle make.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an HTTP response indicating whether the update was successful.
    /// If validation fails or the vehicle make is not found, an appropriate HTTP error response is returned.
    /// </returns>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateVehicleMakeDto updateVehicleMakeDto)
    {
        var result = await updateVehicleMakeValidator.ValidateAsync(updateVehicleMakeDto);

        if (!result.IsValid)
        {
            return HandleResult(CreateModelNotValidResult(result.Errors));
        }

        return HandleResult(await service.Update(updateVehicleMakeDto));
    }

    /// <summary>
    /// Deletes a vehicle make by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle make to delete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an HTTP response indicating whether the deletion was successful.
    /// If the vehicle make is not found, an appropriate HTTP error response is returned.
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return HandleResult(await service.Delete(id));
    }
}
