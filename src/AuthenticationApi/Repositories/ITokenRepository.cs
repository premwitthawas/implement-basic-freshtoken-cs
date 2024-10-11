using AuthenticationApi.Models;

namespace AuthenticationApi.Repositories;


public interface ITokenRepository  {
    Task<Token> CreateToken(string usetId,string accessToken, string refreshToken);
}