using AuthenticationApi.Services;
using Microsoft.AspNetCore.Mvc;
using AuthenticationApi.Dtos;
namespace AuthenticationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<ReponseLoginDto>> Login([FromBody] LoginDto loginDto){
            var result = await authService.Login(loginDto);
            return Ok(result);
        }
    }
}