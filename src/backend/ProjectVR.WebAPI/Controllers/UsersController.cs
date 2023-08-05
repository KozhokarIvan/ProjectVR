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
            UsersSearchResponse[] foundUsers = (await _usersService
                .FindUsers(request.Game, request.VrSet, loggedUserGuid))
                .Select(user => user.MapToSearchResponse())
                .ToArray();
            return Ok(foundUsers);
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandomUsers([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader)
        {
            Guid? loggedUserGuid = null;
            if (!string.IsNullOrWhiteSpace(loggedUserHeader) && Guid.TryParse(loggedUserHeader, out Guid loggedUserGuidFromParse))
                loggedUserGuid = loggedUserGuidFromParse;
            UsersSearchResponse[] foundUsers = (await _usersService
                .GetRandomUsers(loggedUserGuid))
                .Select(user => user.MapToSearchResponse())
                .ToArray();

            return Ok(foundUsers);
        }

    }
}
