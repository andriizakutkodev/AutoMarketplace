namespace Application.Services;

using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Results;

public class UsersService : IUsersService
{
    public Task<ServiceResult<UserInfoDto>> Login(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<UserInfoDto>> Register(RegisterDto registerDto)
    {
        throw new NotImplementedException();
    }
}
