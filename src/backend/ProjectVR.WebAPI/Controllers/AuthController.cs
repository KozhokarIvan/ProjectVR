using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.WebAPI.Contracts.Mapping.Responses;
using ProjectVR.WebAPI.Contracts.Requests;

namespace ProjectVR.WebAPI.Controllers;

[Route("api/")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<UsersController> _logger;

    public AuthController(ILogger<UsersController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest credentials)
    {
        var foundUser = await _authService.Login(credentials.Username);
        if (foundUser is null) return NotFound("Unknown user");
        var user = UsersLoginResponseMapping.MapToApi(foundUser);
        return Ok(user);
    }
}