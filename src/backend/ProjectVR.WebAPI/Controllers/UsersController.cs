using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.WebAPI.Contracts.Mapping.Responses;
using ProjectVR.WebAPI.Contracts.Requests;
using ProjectVR.WebAPI.Contracts.Responses;

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
            UsersSearchResponse[] foundUsers = (await _usersService
                .FindUsers(request.Game, request.VrSet))
                .Select(user => user.MapToDomainEntity())
                .ToArray();

            return Ok(foundUsers);
        }

    }
}
