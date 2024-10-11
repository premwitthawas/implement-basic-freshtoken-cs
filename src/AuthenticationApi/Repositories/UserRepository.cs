using AuthenticationApi.Dtos;
using AuthenticationApi.Helpers;
using AuthenticationApi.Infrastures.Data;
using AuthenticationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApi.Repositories;

class UserRepository : IUserRepository
{
    private readonly AuthDbContext context;
    private readonly PasswordHelper passwordHelper;
    public UserRepository(AuthDbContext context, PasswordHelper passwordHelper)
    {
        this.context = context;
        this.passwordHelper = passwordHelper;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var user = await this.context.Users.FirstOrDefaultAsync(x => x.Email == email);
        if (user == null)
        {
            throw new ArgumentException("User Not found");
        }
        return user;
    }

    public async Task<User> GetUserById(string id)
    {
        var user = await this.context.Users.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        if (user == null)
        {
            throw new ArgumentException("User Not found");
        }
        return user;
    }

    public async Task<User> Create(CreateUserDto createUserDto)
    {
        var useExists = await this.context.Users.FirstOrDefaultAsync(x => x.Email == createUserDto.Email);
        if (useExists != null)
        {
            throw new ArgumentException("Email in use already.");
        };
        string passwordhashed = this.passwordHelper.HashePassword(createUserDto.Password);
        User user = new()
        {
            Email = createUserDto.Email,
            Password = passwordhashed,
            Name = createUserDto.Name,
        };
        await this.context.Users.AddAsync(user);
        await this.context.SaveChangesAsync();
        return user;
    }
};