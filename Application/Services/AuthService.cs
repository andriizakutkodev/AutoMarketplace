namespace Application.Services;

using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Results;

/// <summary>
/// Service responsible for handling user authentication operations, including login and registration.
/// </summary>
public class AuthService(
    IUsersService usersService,
    IPasswordHandlerService passwordHandler,
    IJwtService jwtService
    ) : IAuthService
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
        var findUserResult = await usersService.GetByEmail(loginDto.Email);

        if (!findUserResult.IsSuccess)
        {
            return Result<UserInfoDto>.Failure(findUserResult.StatusCode, findUserResult.Message);
        }

        var user = findUserResult.Data;

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

        var user = new User()
        {
            Email = registerDto.Email,
            Name = registerDto.Name,
            Surname = registerDto.Surname,
            PhoneNumber = registerDto.PhoneNumber,
            Password = hashPasswordResult.Data,
            Salt = salt,
            ImgUrl = registerDto.ImgUrl,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
        };

        var createUserResult = await usersService.Create(user);

        if (!createUserResult.IsSuccess)
        {
            return Result<UserInfoDto>.Failure(createUserResult.StatusCode, $"Register failed. {createUserResult.Message}");
        }

        return PrepareUserInfoResult(user);
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
        return new UserInfoDto()
        {
            Email = user.Email,
            Name = user.Name,
            Surname = user.Surname,
            ImgUrl = user.ImgUrl,
        };
    }
}
