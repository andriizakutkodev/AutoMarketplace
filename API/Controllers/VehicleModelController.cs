namespace API.Controllers;

using Application.DTOs;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for managing vehicle models, providing endpoints for CRUD operations.
/// </summary>
/// <remarks>
/// This controller handles operations for creating, updating, retrieving, and deleting vehicle models.
/// It validates the input DTOs using the provided validators and uses the <see cref="IVehicleModelService"/> for business logic.
/// </remarks>
public class VehicleModelController(
    IVehicleModelService service,
    IValidator<CreateVehicleModelDto> createVehicleDtoValidator,
    IValidator<UpdateVehicleModelDto> updateVehicleDtoValidator) : BaseAPIController
{
    /// <summary>
    /// Retrieves all vehicle models.
    /// </summary>
    /// <returns>
    /// An <see cref="IActionResult"/> containing the list of all vehicle models.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return HandleResult(await service.GetAll());
    }

    /// <summary>
    /// Retrieves a specific vehicle model by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle model.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing the vehicle model with the specified ID, if found.
    /// </returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return HandleResult(await service.GetById(id));
    }

    /// <summary>
    /// Creates a new vehicle model.
    /// </summary>
    /// <param name="createVehicleModelDto">The DTO containing data for the new vehicle model.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> indicating the result of the create operation.
    /// </returns>
    /// <remarks>
    /// Validates the input DTO using the <see cref="IValidator{T}"/> for <see cref="CreateVehicleModelDto"/> before calling the service layer.
    /// </remarks>
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateVehicleModelDto createVehicleModelDto)
    {
        var result = await createVehicleDtoValidator.ValidateAsync(createVehicleModelDto);

        if (!result.IsValid)
        {
            return HandleResult(CreateModelNotValidResult(result.Errors));
        }

        return HandleResult(await service.Create(createVehicleModelDto));
    }

    /// <summary>
    /// Updates an existing vehicle model.
    /// </summary>
    /// <param name="updateVehicleModelDto">The DTO containing updated data for the vehicle model.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> indicating the result of the update operation.
    /// </returns>
    /// <remarks>
    /// Validates the input DTO using the <see cref="IValidator{T}"/> for <see cref="UpdateVehicleModelDto"/> before calling the service layer.
    /// </remarks>
    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateVehicleModelDto updateVehicleModelDto)
    {
        var result = await updateVehicleDtoValidator.ValidateAsync(updateVehicleModelDto);

        if (!result.IsValid)
        {
            return HandleResult(CreateModelNotValidResult(result.Errors));
        }

        return HandleResult(await service.Update(updateVehicleModelDto));
    }

    /// <summary>
    /// Deletes a specific vehicle model by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle model to delete.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> indicating the result of the delete operation.
    /// </returns>
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return HandleResult(await service.Delete(id));
    }
}
