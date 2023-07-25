using System;
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
        private readonly IFriendsService _friendsService;
        public UsersController(ILogger<UsersController> logger, IUsersService usersService, IFriendsService friendsService)
        {
            _logger = logger;
            _usersService = usersService;
            _friendsService = friendsService;
        }
        [HttpPost("friends")]
        public async Task<IActionResult> AddFriend([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader, [FromBody] AddFriendRequest request)
        {
            if (loggedUserHeader is null) return BadRequest("Missing 'loggedUserGuid' header");

            if (!Guid.TryParse(loggedUserHeader, out Guid loggedUserGuid))
            {
                return BadRequest("Failed to parse passed loggerUserGuid");
            }
            if (loggedUserGuid == request.UserToAddGuid) return BadRequest("You cant add yourself");
            bool isAdded = await _friendsService.AddFriend(loggedUserGuid, request.UserToAddGuid);
            return isAdded ? Ok("Success") : BadRequest("Something went wrong");
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
