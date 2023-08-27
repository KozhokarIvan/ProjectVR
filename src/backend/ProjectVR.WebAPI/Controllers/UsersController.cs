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
        public UsersController(ILogger<UsersController> logger, IUsersService usersService, IFriendsService friendsService)
        {
            _logger = logger;
            _usersService = usersService;
        }
        [HttpGet]
        public async Task<IActionResult> Search([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader, [FromQuery] UsersSearchRequest request)
        {
            Guid? loggedUserGuid = null;
            if (!string.IsNullOrWhiteSpace(loggedUserHeader) && Guid.TryParse(loggedUserHeader, out Guid loggedUserGuidFromParse))
                loggedUserGuid = loggedUserGuidFromParse;
            var users = await _usersService
                .FindUsersByGameOrVrset(request.Game, request.VrSet, request.Offset, request.Limit, loggedUserGuid);
            var result = users
                .Select(user => user.MapToSearchResponse())
                .ToArray();
            return Ok(users);
        }

        [HttpGet("random/{limit:int}")]
        public async Task<IActionResult> GetRandomUsers([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader, int limit)
        {
            if (limit <= 0)
                return BadRequest("limit can not be less than 1");
            Guid? loggedUserGuid = null;
            if (!string.IsNullOrWhiteSpace(loggedUserHeader) && Guid.TryParse(loggedUserHeader, out Guid loggedUserGuidFromParse))
                loggedUserGuid = loggedUserGuidFromParse;
            UsersSearchResponse[] foundUsers = (await _usersService
                .GetRandomUsers(limit,loggedUserGuid))
                .Select(user => user.MapToSearchResponse())
                .ToArray();

            return Ok(foundUsers);
        }

    }
}
