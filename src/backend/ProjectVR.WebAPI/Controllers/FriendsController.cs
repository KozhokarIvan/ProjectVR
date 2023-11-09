using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectVR.Domain.Interfaces.Services;

namespace ProjectVR.WebAPI.Controllers;

[Route("api/friends/")]
[ApiController]
public class FriendsController : ControllerBase
{
    private readonly IFriendsService _friendsService;

    public FriendsController(IFriendsService friendsService)
    {
        _friendsService = friendsService;
    }

    [HttpPost("{friendGuid:guid}")]
    public async Task<IActionResult> SendFriendRequest([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader,
        Guid friendGuid)
    {
        if (loggedUserHeader is null) return BadRequest("Missing 'loggedUserGuid' header");

        if (!Guid.TryParse(loggedUserHeader, out var loggedUserGuid))
            return BadRequest("Failed to parse passed loggerUserGuid");

        var result = await _friendsService.SendFriendRequest(loggedUserGuid, friendGuid);
        return result ? Ok("Successfully sent friend request") : BadRequest("Something went wrong");
    }

    [HttpPut("requests/{userGuid:guid}")]
    public async Task<IActionResult> AcceptFriendRequest([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader,
        Guid userGuid)
    {
        if (loggedUserHeader is null) return BadRequest("Missing 'loggedUserGuid' header");

        if (!Guid.TryParse(loggedUserHeader, out var loggedUserGuid))
            return BadRequest("Failed to parse passed loggerUserGuid");

        var result = await _friendsService.AcceptFriendRequest(loggedUserGuid, userGuid);
        return result ? Ok("Successfully accepted friend request") : BadRequest("Something went wrong");
    }

    [HttpDelete("requests/{userGuid:guid}")]
    public async Task<IActionResult> DeclineFriendRequest(
        [FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader, Guid userGuid)
    {
        if (loggedUserHeader is null) return BadRequest("Missing 'loggedUserGuid' header");

        if (!Guid.TryParse(loggedUserHeader, out var loggedUserGuid))
            return BadRequest("Failed to parse passed loggerUserGuid");

        var result = await _friendsService.DeclineFriendRequest(userGuid, loggedUserGuid);
        return result ? Ok("Successfully declined friend request") : BadRequest("Something went wrong");
    }

    [HttpDelete("{friendGuid:guid}")]
    public async Task<IActionResult> DeleteFriend([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader,
        Guid friendGuid)
    {
        if (loggedUserHeader is null) return BadRequest("Missing 'loggedUserGuid' header");

        if (!Guid.TryParse(loggedUserHeader, out var loggedUserGuid))
            return BadRequest("Failed to parse passed loggerUserGuid");

        var result = await _friendsService.DeleteFriend(loggedUserGuid, friendGuid);
        return result ? Ok("Successfully deleted friend") : BadRequest("Something went wrong");
    }
}