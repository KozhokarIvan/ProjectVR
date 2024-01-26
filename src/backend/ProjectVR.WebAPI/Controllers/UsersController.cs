using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.Domain.Models.User.Enums;
using ProjectVR.WebAPI.Contracts.Mapping;
using ProjectVR.WebAPI.Contracts.Mapping.Responses;
using ProjectVR.WebAPI.Contracts.Requests;
using ProjectVR.WebAPI.Contracts.Responses;

namespace ProjectVR.WebAPI.Controllers;

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
    public async Task<IActionResult> GetUsers([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader,
        [FromQuery] GetUsersRequest request)
    {
        if (request.Limit < 1)
            return BadRequest("Limit should be greater than 0");
        if (request.Offset < 0)
            return BadRequest("Offset should be positive number");
        Guid? loggedUserGuid = null;
        if (!string.IsNullOrWhiteSpace(loggedUserHeader) &&
            Guid.TryParse(loggedUserHeader, out var loggedUserGuidFromParse))
            loggedUserGuid = loggedUserGuidFromParse;
        var users = await _usersService
            .FindUsersByGameAndVrset(request.Game, request.VrSet, request.Offset, request.Limit, loggedUserGuid);
        var result = users
            .Select(GetUsersResponseMappingExtension.MapToApi)
            .ToArray();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        var creationResult =
            await _usersService.CreateUser(request.Username, request.Email, request.Avatar, request.Password);
        if (creationResult.IsSuccess)
        {
            var user = creationResult.Value;
            return Ok(new CreateUserResponse
            {
                UserCreationStatus = "Created",
                User = UserMappingExtension.MapToApi(user)
            });
        }

        var error = creationResult.ErrorStatus.ToString();
        if (string.IsNullOrWhiteSpace(error))
            throw new NullReferenceException();
        var response = new CreateUserResponse
        {
            UserCreationStatus = error
        };
        switch (creationResult.ErrorStatus)
        {
            case RegisterUserError.InvalidUsername:
            case RegisterUserError.InvalidEmail:
            case RegisterUserError.InvalidAvatar:
                return BadRequest(response);
            case RegisterUserError.UsernameIsTaken:
            case RegisterUserError.EmailIsTaken:
                return Conflict(response);
            default:
                throw new NullReferenceException();
        }
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> GetUser([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader,
        string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            return BadRequest("Username is empty");
        Guid? loggedUserGuid = null;
        if (!string.IsNullOrWhiteSpace(loggedUserHeader) &&
            Guid.TryParse(loggedUserHeader, out var loggedUserGuidFromParse))
            loggedUserGuid = loggedUserGuidFromParse;
        var domainUser = await _usersService.GetUserDetailsByUsername(username, loggedUserGuid);
        if (domainUser is null) return NotFound($"No user with username '{username}'");
        var user = GetDetailedUserInfoResponseMappingExtension.MapToApi(domainUser);
        return Ok(user);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchUsers([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader,
        [FromQuery] SearchUsersRequest request)
    {
        if (request.Limit < 1)
            return BadRequest("Limit should be greater than 0");
        if (request.Offset < 0)
            return BadRequest("Offset should be positive number");
        Guid? loggedUserGuid = null;
        if (!string.IsNullOrWhiteSpace(loggedUserHeader) &&
            Guid.TryParse(loggedUserHeader, out var loggedUserGuidFromParse))
            loggedUserGuid = loggedUserGuidFromParse;
        var users = await _usersService
            .FindUsersByGameOrVrSet(request.SearchQuery, request.Offset, request.Limit, loggedUserGuid);
        var response = users.Select(user => SearchUsersResponseMappingExtension.MapToApi(user));
        return Ok(response);
    }

    [HttpGet("random/{limit:int}")]
    public async Task<IActionResult> GetRandomUsers([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader,
        int limit)
    {
        Guid? loggedUserGuid = null;
        if (!string.IsNullOrWhiteSpace(loggedUserHeader) &&
            Guid.TryParse(loggedUserHeader, out var loggedUserGuidFromParse))
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