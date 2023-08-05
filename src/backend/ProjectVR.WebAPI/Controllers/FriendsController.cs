using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectVR.Domain.Interfaces.Services;

namespace ProjectVR.WebAPI.Controllers
{
    [Route("api/friends/")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly IFriendsService _friendsService;
        public FriendsController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }
        [HttpPost("{userToAdd:guid}")]
        public async Task<IActionResult> SendFriendRequest([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader, Guid userToAdd)
        {
            if (loggedUserHeader is null) return BadRequest("Missing 'loggedUserGuid' header");

            if (!Guid.TryParse(loggedUserHeader, out Guid loggedUserGuid))
            {
                return BadRequest("Failed to parse passed loggerUserGuid");
            }

            var result = await _friendsService.SendFriendRequest(loggedUserGuid, userToAdd);
            return result ? Ok("Successfully sent friend request") : BadRequest("Something went wrong");
        }
        [HttpPost("requests/{userToAccept:guid}")]
        public async Task<IActionResult> AcceptFriendRequest([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader, Guid userToAccept)
        {
            if (loggedUserHeader is null) return BadRequest("Missing 'loggedUserGuid' header");

            if (!Guid.TryParse(loggedUserHeader, out Guid loggedUserGuid))
            {
                return BadRequest("Failed to parse passed loggerUserGuid");
            }

            var result = await _friendsService.AcceptFriendRequest(userToAccept, loggedUserGuid);
            return result ? Ok("Successfully accepted friend request") : BadRequest("Something went wrong");
        }
        [HttpDelete("requests/{userToDecline:guid}")]
        public async Task<IActionResult> DeclineFriendRequest([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader, Guid userToDecline)
        {
            if (loggedUserHeader is null) return BadRequest("Missing 'loggedUserGuid' header");

            if (!Guid.TryParse(loggedUserHeader, out Guid loggedUserGuid))
            {
                return BadRequest("Failed to parse passed loggerUserGuid");
            }

            var result = await _friendsService.DeclineFriendRequest(userToDecline, loggedUserGuid);
            return result ? Ok("Successfully declined friend request") : BadRequest("Something went wrong");
        }

        [HttpDelete("friendToDelete:guid")]
        public async Task<IActionResult> DeleteFriend([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader, Guid friendToDelete)
        {
            if (loggedUserHeader is null) return BadRequest("Missing 'loggedUserGuid' header");

            if (!Guid.TryParse(loggedUserHeader, out Guid loggedUserGuid))
            {
                return BadRequest("Failed to parse passed loggerUserGuid");
            }

            var result = await _friendsService.DeleteFriend(loggedUserGuid, friendToDelete);
            return result ? Ok("Successfully deleted friend") : BadRequest("Something went wrong");
        }
        [HttpPut("requests/{userToCancel:guid}")]
        public async Task<IActionResult> CancelFriendRequest([FromHeader(Name = "loggedUserGuid")] string? loggedUserHeader, Guid userToCancel)
        {
            if (loggedUserHeader is null) return BadRequest("Missing 'loggedUserGuid' header");

            if (!Guid.TryParse(loggedUserHeader, out Guid loggedUserGuid))
            {
                return BadRequest("Failed to parse passed loggerUserGuid");
            }
            var result = await _friendsService.CancelFriendRequest(loggedUserGuid, userToCancel);
            return result ? Ok("Successfully cancelled friend request") : BadRequest("Something went wrong");
        }
    }
}
