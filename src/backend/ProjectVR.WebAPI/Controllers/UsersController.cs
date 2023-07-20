using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.WebAPI.Contracts.Mapping.Responses;
using ProjectVR.WebAPI.Contracts.Requests;
using ProjectVR.WebAPI.Contracts.Responses;


namespace ProjectVR.WebAPI.Controllers
{
    [Route("api/users/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUsersService _usersService;
        public UsersController(ILogger<UsersController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] UsersSearchRequest request)
        {
            UsersSearchResponse[] foundUsers = (await _usersService
                .FindUsers(request.Game, request.VrSet))
                .Select(user => user.MapToSearchResponse())
                .ToArray();
            return Ok(foundUsers);
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandomUsers()
        {
            UsersSearchResponse[] foundUsers = (await _usersService
                .GetRandomUsers())
                .Select(user => user.MapToSearchResponse())
                .ToArray();

            return Ok(foundUsers);
        }

    }
}
