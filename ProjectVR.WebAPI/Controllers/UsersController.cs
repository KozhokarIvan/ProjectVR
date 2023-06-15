using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectVR.Domain.Entities;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.WebAPI.Contracts.Requests;

namespace ProjectVR.WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] UsersSearchRequest request)
        {
            List<UserInfo> foundUsers = await _usersService.FindUsers(request.Game, request.VrSet);
            return Ok(foundUsers);
        }

    }
}
