using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.WebAPI.Contracts.Mapping.Responses;
using ProjectVR.WebAPI.Contracts.Requests;
using ProjectVR.WebAPI.Contracts.Responses;

namespace ProjectVR.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IAuthService _authService;
        public AuthController(ILogger<UsersController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest credentials)
        {
            Domain.Models.UserInfo? foundUser = await _authService.Login(credentials.Username);
            if (foundUser is null) return NotFound("Unknown user");
            LoginResponse user = foundUser.MapToLoginResponse();
            return Ok(user);
        }
    }
}
