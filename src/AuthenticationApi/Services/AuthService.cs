using AuthenticationApi.Dtos;
using AuthenticationApi.Helpers;
using AuthenticationApi.Repositories;

namespace AuthenticationApi.Services;

public class AuthServic(IAuthRepository authRepository, JwtHelper jwtHelper,ITokenRepository tokenRepository) : IAuthService
{

    public async Task<ReponseLoginDto> Login(LoginDto loginDto)
    {
        var user = await authRepository.ValidateUser(loginDto.Email, loginDto.Password);
        var acctoken = jwtHelper.GenereateAccessToken(user.Id.ToString(), user.Role);
        var reftoken = jwtHelper.GenereateRefreshToken(user.Id.ToString(), user.Role);
        var token = await tokenRepository.CreateToken(user.Id.ToString(), acctoken, reftoken);
        return new ReponseLoginDto
        {
            Id = user.Id.ToString(),
            Accesstoken = token.AccessToken,
            Refeshtoken = token.RefreshToken,
        };
    }
};