﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.Domain.Models.User.Enums;
using ProjectVR.WebAPI.Contracts.Mapping;
using ProjectVR.WebAPI.Contracts.Mapping.Request;
using ProjectVR.WebAPI.Contracts.Mapping.Responses;
using ProjectVR.WebAPI.Contracts.Requests;
using ProjectVR.WebAPI.Contracts.Responses;

namespace ProjectVR.WebAPI.Controllers;

[Route("api/users/")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers(
        [FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader,
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
            .FindUsersByGameAndVrSet(request.Game, request.VrSet, request.Offset, request.Limit, loggedUserGuid);
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
            return BadRequest(error);
        var response = new CreateUserResponse
        {
            UserCreationStatus = error
        };
        return creationResult.ErrorStatus switch
        {
            RegisterUserError.InvalidUsername or RegisterUserError.InvalidEmail or RegisterUserError.InvalidAvatar => BadRequest(response),
            RegisterUserError.UsernameIsTaken or RegisterUserError.EmailIsTaken => Conflict(response),
            _ => BadRequest("Unknown error on creating user"),
        };
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> GetUserByUsername(
        [FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader,
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
    public async Task<IActionResult> SearchUsers(
        [FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader,
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
    public async Task<IActionResult> GetRandomUsers(
        [FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader,
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

    [HttpGet("vrsets")]
    public async Task<IActionResult> GetUserVrSets(
        [FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader,
        [FromQuery] GetUserVrSetsRequest request)
    {
        if (!Guid.TryParse(loggedUserHeader, out var loggedUserGuid))
            return Unauthorized();
        if (request.Limit <= 0) return BadRequest("limit can not be less than 1");
        if (request.Offset < 0) return BadRequest("offset can not be less than 0");
        var offset = request.Offset ?? 0;
        var limit = request.Limit;
        var userVrSets = await _usersService.GetUserVrSets(loggedUserGuid, limit, offset);
        return Ok(userVrSets);
    }

    [HttpPut("vrsets")]
    public async Task<IActionResult> SetUserVrSets(
        [FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader,
        [FromBody] SetUserVrSetsRequest request)
    {
        if (!Guid.TryParse(loggedUserHeader, out var loggedUserGuid))
            return Unauthorized();
        await _usersService.SetUserVrSets(loggedUserGuid, request.VrSets.MapToDomain());
        return Ok();
    }
}