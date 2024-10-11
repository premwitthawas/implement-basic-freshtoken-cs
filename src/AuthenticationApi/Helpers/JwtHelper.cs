using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthenticationApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationApi.Helpers;

public class JwtHelper
{
    private readonly IConfiguration configuration;
    public JwtHelper(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public string GenereateAccessToken(string id, Role role)
    {
        var key = Encoding.ASCII.GetBytes(this.configuration["JwtAccessTokenKey"]);
        var handler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
             new(ClaimTypes.NameIdentifier, id),
            new(ClaimTypes.Role, role.ToString())
         ]),
            Expires = DateTime.UtcNow.AddMinutes(3),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = "localhost",
            Audience = "localhost",
        };
        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }
    public string GenereateRefreshToken(string id, Role role)
    {
        var key = Encoding.ASCII.GetBytes(this.configuration["jwtRefreshTokenKey"]);
        var handler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
             new(ClaimTypes.NameIdentifier, id),
             new(ClaimTypes.Role, role.ToString())
         ]),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = "localhost",
            Audience = "localhost",
        };
        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }
};