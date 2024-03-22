using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectVR.Domain.Interfaces.Services;

namespace ProjectVR.WebAPI.Controllers;

[ApiController]
[Route("api/vrsets/")]
public class VrSetsController : ControllerBase
{
    private readonly IVrSetsService _vrSetsService;

    public VrSetsController(IVrSetsService vrSetsService)
    {
        _vrSetsService = vrSetsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVrSets([FromQuery] int limit, [FromQuery] int offset)
    {
        if (limit < 1) return BadRequest("Limit can't be less than 1");
        if (offset < 0) return BadRequest("Offset can't be less than 0");
        var vrSets = await _vrSetsService.GetVrSets(limit, offset);
        return Ok(vrSets);
    }
}