using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectVR.DataAccess.Mapping;
using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Models.VrSet;

namespace ProjectVR.DataAccess.Repositories;

public class VrSetsRepository : IVrSetsRepository
{
    private readonly ProjectVRDbContext _context;
    public VrSetsRepository(ProjectVRDbContext context)
    {
        _context = context;
    }

    public async Task<VrSet[]> GetVrSets(int limit, int offset)
    {
        var vrSets = await _context.VrSets
            .Skip(offset)
            .Take(limit)
            .OrderBy(vs => vs.Name)
            .Select(vs => vs.MapToDomain())
            .ToArrayAsync();
        return vrSets;
    }
}