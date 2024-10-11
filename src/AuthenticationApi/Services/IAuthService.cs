using AuthenticationApi.Dtos;

namespace AuthenticationApi.Services;

public interface IAuthService {
    Task<ReponseLoginDto> Login(LoginDto loginDto);
};