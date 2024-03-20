using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Interfaces.Services;
using ProjectVR.Domain.Models.VrSet;

namespace ProjectVR.BusinessLogic.Services;

public class VrSetsService : IVrSetsService
{
    private readonly IVrSetsRepository _vrSetsRepository;
    public VrSetsService(IVrSetsRepository vrSetsRepository)
    {
        _vrSetsRepository = vrSetsRepository;
    }

    public Task<VrSet[]> GetVrSets(int limit, int offset)
        => _vrSetsRepository.GetVrSets(limit, offset);
}