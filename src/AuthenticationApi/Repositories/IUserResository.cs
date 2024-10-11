using AuthenticationApi.Dtos;
using AuthenticationApi.Models;

namespace AuthenticationApi.Repositories;

public interface IUserRepository {
    Task<User> Create(CreateUserDto user);
    Task<User> GetUserById(string id);
    Task<User> GetUserByEmail(string email);
}