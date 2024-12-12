namespace API.Controllers;

using API.Extensions;
using Application.DTOs;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for managing announcements in the system.
/// Provides endpoints to create, retrieve, update, and delete announcements.
/// </summary>
public class AnnouncementsController(
    IAnnouncementsService service,
    IValidator<CreateAnnouncementDto> createAnnouncementDtoValidator,
    IValidator<UpdateAnnouncementDto> updateAnnouncementDtoValidator) : BaseAPIController
{
    /// <summary>
    /// Retrieves all announcements.
    /// </summary>
    /// <returns>
    /// A collection of <see cref="AnnouncementDto"/> objects representing the announcements.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return HandleResult(await service.GetAll());
    }

    /// <summary>
    /// Retrieves a specific announcement by its ID.
    /// </summary>
    /// <param name="id">The ID of the announcement to retrieve.</param>
    /// <returns>
    /// An <see cref="AnnouncementDto"/> object if found; otherwise, a not found result.
    /// </returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return HandleResult(await service.GetById(id));
    }

    /// <summary>
    /// Creates a new announcement.
    /// </summary>
    /// <param name="createAnnouncementDto">The DTO containing the data for the announcement to create.</param>
    /// <returns>
    /// A success result if the announcement is created successfully; otherwise, a bad request or validation error result.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateAnnouncementDto createAnnouncementDto)
    {
        var result = await createAnnouncementDtoValidator.ValidateAsync(createAnnouncementDto);

        if (!result.IsValid)
        {
            return HandleResult(CreateModelNotValidResult(result.Errors));
        }

        var userId = Guid.Parse(HttpContext.GetSessionUserId() ?? throw new UnauthorizedAccessException());

        return HandleResult(await service.Create(createAnnouncementDto, userId));
    }

    /// <summary>
    /// Updates an existing announcement.
    /// </summary>
    /// <param name="updateAnnouncementDto">The DTO containing the data for the announcement to update.</param>
    /// <returns>
    /// A success result if the announcement is updated successfully; otherwise, a bad request or validation error result.
    /// </returns>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateAnnouncementDto updateAnnouncementDto)
    {
        var result = await updateAnnouncementDtoValidator.ValidateAsync(updateAnnouncementDto);

        if (!result.IsValid)
        {
            return HandleResult(CreateModelNotValidResult(result.Errors));
        }

        return HandleResult(await service.Update(updateAnnouncementDto));
    }

    /// <summary>
    /// Deletes an existing announcement by its ID.
    /// </summary>
    /// <param name="id">The ID of the announcement to delete.</param>
    /// <returns>
    /// A success result if the announcement is deleted successfully; otherwise, a not found or bad request result.
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return HandleResult(await service.Delete(id));
    }
}
