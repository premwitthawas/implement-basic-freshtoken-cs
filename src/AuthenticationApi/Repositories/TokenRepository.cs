using AuthenticationApi.Infrastures.Data;
using AuthenticationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApi.Repositories;

public class TokenRepository(AuthDbContext authDbContext) : ITokenRepository
{
    public async Task<Token> CreateToken(string usetId, string accessToken, string refreshToken)
    {
        var user = await authDbContext.Users.FirstOrDefaultAsync(x => x.Id == Guid.Parse(usetId));
        if (user == null)
        {
            throw new KeyNotFoundException("UserNotfound");
        }
        if (accessToken == null || refreshToken == null)
        {
            throw new ArgumentNullException("accessToken | refreshToken is not null");
        }
        var token = new Token
        {
            AccessToken = accessToken,
            RefreshToken = accessToken,
            UserId = user.Id,
            IsRevoked = true,
        };
        await authDbContext.Tokens.AddAsync(token);
        await authDbContext.SaveChangesAsync();
        return token;
    }
}