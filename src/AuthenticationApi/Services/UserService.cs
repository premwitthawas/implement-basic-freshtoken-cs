
using AuthenticationApi.Dtos;
using AuthenticationApi.Repositories;

namespace AuthenticationApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<ResponseUserDto> Register(CreateUserDto createUserDto)
        {
            var user = await this._userRepository.Create(createUserDto);
            return new ResponseUserDto
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                Name = user.Name,
            };
        }
    }
}