using Microsoft.AspNetCore.Mvc;
using ProjectVR.WebAPI.Contracts;
using ProjectVR.WebAPI.Entities;
using ProjectVR.WebAPI.StaticData;

namespace ProjectVR.WebAPI.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersData _usersData;
        public UsersController(UsersData usersData)
        {
            _usersData = usersData;
        }
        [Route("/users")]
        [HttpGet]
        public IActionResult Search([FromQuery] UsersSearchParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            List<Userinfo> foundUsers = _usersData.Users
                .Where(u =>
                    (parameters.Game is null || u.Games.Any(g => g.Name.Contains(parameters.Game))) 
                    &&
                    (parameters.VrSet is null || u.VrSets.Any(vs => vs.Name.Contains(parameters.VrSet))))
                .ToList();
            return Ok(foundUsers);
        }
    }
}
