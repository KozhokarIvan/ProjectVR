using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.WebAPI.Contracts.Mapping.Responses;
using ProjectVR.WebAPI.Contracts.Requests;


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
        public async Task<IActionResult> GetUsers([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader, [FromQuery] GetUsersRequest request)
        {
            if (request.Limit < 1)
                return BadRequest("Limit should be greater than 0");
            if (request.Offset < 0)
                return BadRequest("Offset should be positive number");
            Guid? loggedUserGuid = null;
            if (!string.IsNullOrWhiteSpace(loggedUserHeader) && Guid.TryParse(loggedUserHeader, out Guid loggedUserGuidFromParse))
                loggedUserGuid = loggedUserGuidFromParse;
            var users = await _usersService
                .FindUsersByGameAndVrset(request.Game, request.VrSet, request.Offset, request.Limit, loggedUserGuid);
            var result = users
                .Select(user => user.MapToGetUsersResponse())
                .ToArray();
            return Ok(result);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchUsers([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader, [FromQuery] SearchUsersRequest request)
        {
            if (request.Limit < 1)
                return BadRequest("Limit should be greater than 0");
            if (request.Offset < 0)
                return BadRequest("Offset should be positive number");
            Guid? loggedUserGuid = null;
            if (!string.IsNullOrWhiteSpace(loggedUserHeader) && Guid.TryParse(loggedUserHeader, out Guid loggedUserGuidFromParse))
                loggedUserGuid = loggedUserGuidFromParse;
            var users = await _usersService
                .FindUsersByGameOrVrSet(request.SearchQuery, request.Offset, request.Limit, loggedUserGuid);
            var response = users.Select(user => user.MapToSearchResponse());
            return Ok(response);
        }

        [HttpGet("random/{limit:int}")]
        public async Task<IActionResult> GetRandomUsers([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader, int limit)
        {
            Guid? loggedUserGuid = null;
            if (!string.IsNullOrWhiteSpace(loggedUserHeader) && Guid.TryParse(loggedUserHeader, out Guid loggedUserGuidFromParse))
                loggedUserGuid = loggedUserGuidFromParse;
            if (limit <= 0)
                return BadRequest("limit can not be less than 1");
            var foundUsers = (await _usersService
                .GetRandomUsers(limit, loggedUserGuid))
                .Select(user => user.MapToGetRandomUsersResponse())
                .ToArray();
            return Ok(foundUsers);
        }
    }
}
