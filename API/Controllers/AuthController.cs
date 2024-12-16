namespace API.Controllers;

using API.Extensions;

using Application.DTOs;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents the authentication controller responsible for handling user registration and login operations.
/// </summary>
public class AuthController(
    IAuthService service,
    IValidator<LoginDto> loginDtoValidator,
    IValidator<RegisterDto> registerDtoValidator) : BaseAPIController
{
    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="registerDto">The data transfer object containing the user's registration details.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the registration process.</returns>
    /// <remarks>
    /// The method validates the provided <paramref name="registerDto"/> using the <see cref="IValidator{T}"/> implementation.
    /// If validation fails, it returns a bad request with the validation errors.
    /// Otherwise, it delegates the registration process to the <see cref="IAuthService"/> service.
    /// </remarks>
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var result = await registerDtoValidator.ValidateAsync(registerDto);

        if (!result.IsValid)
        {
            return HandleResult(CreateModelNotValidResult(result.Errors));
        }

        return HandleResult(await service.Register(registerDto));
    }

    /// <summary>
    /// Logs in a user.
    /// </summary>
    /// <param name="loginDto">The data transfer object containing the user's login credentials.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the login process.</returns>
    /// <remarks>
    /// The method validates the provided <paramref name="loginDto"/> using the <see cref="IValidator{T}"/> implementation.
    /// If validation fails, it returns a bad request with the validation errors.
    /// Otherwise, it delegates the login process to the <see cref="IAuthService"/> service.
    /// </remarks>
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var result = await loginDtoValidator.ValidateAsync(loginDto);

        if (!result.IsValid)
        {
            return HandleResult(CreateModelNotValidResult(result.Errors));
        }

        return HandleResult(await service.Login(loginDto));
    }

    /// <summary>
    /// Retrieves the information of the currently authenticated user.
    /// </summary>
    /// <returns>
    /// An <see cref="IActionResult"/> containing the user's information if the operation is successful.
    /// </returns>
    /// <remarks>
    /// The user must be authenticated to access this endpoint.
    /// </remarks>
    [Authorize]
    [HttpGet("user-info")]
    public async Task<IActionResult> GetUserInfo()
    {
        return HandleResult(await service.GetUserInfo(HttpContext.GetLoggedUserId()));
    }
}
