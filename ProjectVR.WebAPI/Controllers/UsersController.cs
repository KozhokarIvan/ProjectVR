using Microsoft.AspNetCore.Mvc;
using ProjectVR.Domain.Entities;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.WebAPI.Contracts;

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
        public IActionResult Search([FromQuery] UsersSearchRequest request)
        {
            List<Userinfo> foundUsers = _usersService.FindUsers(request.Game, request.VrSet);
            return Ok(foundUsers);
        }

    }
}
