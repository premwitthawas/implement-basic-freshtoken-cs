using AuthenticationApi.Models;
namespace AuthenticationApi.Repositories;
public interface IAuthRepository {
    Task<User> ValidateUser(string Email, string Password);
}