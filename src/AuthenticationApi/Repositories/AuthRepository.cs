using AuthenticationApi.Helpers;
using AuthenticationApi.Infrastures.Data;
using AuthenticationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApi.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly AuthDbContext context;
    private readonly PasswordHelper passwordHelper;
    public AuthRepository(AuthDbContext context, PasswordHelper passwordHelper)
    {
        this.context = context;
        this.passwordHelper = passwordHelper;
    }
    public async Task<User> ValidateUser(string email, string password)
    {
        var user = await this.context.Users.FirstOrDefaultAsync(x => x.Email == email);
        if (user == null)
        {
            throw new KeyNotFoundException("User Not found | Register please");
        }
        bool passwordMatched = this.passwordHelper.VerfifyPassword(password, user.Password);
        if(!passwordMatched)
        {
            throw new UnauthorizedAccessException("Password Not Matched");
        }
        return user;
    }
}