namespace Application.Services;

using System;
using System.Net;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Results;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Service responsible for handling user authentication operations, including login and registration.
/// </summary>
public class AuthService(AppDbContext context,
    IPasswordHandlerService passwordHandler,
    IJwtService jwtService,
    IMapper mapper) : IAuthService
{
    /// <summary>
    /// Logs in a user by validating their credentials and generating a JWT token.
    /// </summary>
    /// <param name="loginDto">The data transfer object containing login credentials.</param>
    /// <returns>
    /// A <see cref="Result{UserInfoDto}"/> containing the user information and token if successful,
    /// or an error result if login fails.
    /// </returns>
    public async Task<Result<UserInfoDto>> Login(LoginDto loginDto)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

        if (user is null)
        {
            return Result<UserInfoDto>.Failure(HttpStatusCode.NotFound, $"User with {loginDto.Email} email was not found.");
        }

        var validatePasswordResult = passwordHandler.ValidatePassword(loginDto.Password, user.Password, user.Salt);

        if (!validatePasswordResult.IsSuccess)
        {
            return Result<UserInfoDto>.Failure(validatePasswordResult.StatusCode, validatePasswordResult.Message);
        }

        return PrepareUserInfoResult(user);
    }

    /// <summary>
    /// Registers a new user by hashing the password and saving the user's information.
    /// </summary>
    /// <param name="registerDto">The data transfer object containing registration information.</param>
    /// <returns>
    /// A <see cref="Result{UserInfoDto}"/> containing the new user information and token if registration is successful,
    /// or an error result if registration fails.
    /// </returns>
    public async Task<Result<UserInfoDto>> Register(RegisterDto registerDto)
    {
        var hashPasswordResult = passwordHandler.HashPassword(registerDto.Password, out byte[] salt);

        var user = mapper.Map<User>(registerDto);

        user.Password = hashPasswordResult.Data;
        user.Salt = salt;
        user.Image = default;

        context.Users.Add(user);

        var isCreated = await context.SaveChangesAsync() > 0;

        if (!isCreated)
        {
            return Result<UserInfoDto>.Failure(HttpStatusCode.BadRequest, $"Register failed.");
        }

        return PrepareUserInfoResult(user);
    }

    /// <summary>
    /// Retrieves user information based on the provided user ID.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
    /// The result contains a <see cref="Result{T}"/> object with a <see cref="UserInfoDto"/>
    /// containing user information if the operation is successful.
    /// </returns>
    public async Task<Result<UserInfoDto>> GetUserInfo(Guid id)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

        var userInfoDto = mapper.Map<UserInfoDto>(user);

        return Result<UserInfoDto>.Success(userInfoDto);
    }

    /// <summary>
    /// Prepares the user information, including generating a JWT token for the user.
    /// </summary>
    /// <param name="user">The user entity to prepare the information for.</param>
    /// <returns>
    /// A <see cref="Result{UserInfoDto}"/> containing the user information and token.
    /// </returns>
    private Result<UserInfoDto> PrepareUserInfoResult(User user)
    {
        var userInfo = CreateNewUserInfoDto(user);

        var generateTokenResult = jwtService.GenerateToken(user);

        if (!generateTokenResult.IsSuccess)
        {
            return Result<UserInfoDto>.Failure(generateTokenResult.StatusCode, generateTokenResult.Message);
        }

        userInfo.Token = generateTokenResult.Data;

        return Result<UserInfoDto>.Success(userInfo);
    }

    /// <summary>
    /// Creates a <see cref="UserInfoDto"/> from the user entity.
    /// </summary>
    /// <param name="user">The user entity.</param>
    /// <returns>A <see cref="UserInfoDto"/> containing the user information.</returns>
    private UserInfoDto CreateNewUserInfoDto(User user)
    {
        return mapper.Map<UserInfoDto>(user);
    }
}
