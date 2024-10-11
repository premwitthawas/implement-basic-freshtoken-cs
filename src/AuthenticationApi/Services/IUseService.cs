using AuthenticationApi.Dtos;

namespace AuthenticationApi.Services;

public interface IUserService
{
    Task<ResponseUserDto> Register(CreateUserDto createUserDto);
}