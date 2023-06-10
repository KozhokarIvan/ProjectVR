using Microsoft.AspNetCore.Mvc;
using ProjectVR.Domain.Entities;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.WebAPI.Contracts;

namespace ProjectVR.WebAPI.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [Route("/users")]
        [HttpGet]
        public IActionResult Search([FromQuery] UsersSearchParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            List<Userinfo> foundUsers = _usersService.FindUsers(parameters.Game, parameters.VrSet);
            return Ok(foundUsers);
        }
    }
}
