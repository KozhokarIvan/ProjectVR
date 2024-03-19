using System.Linq;

namespace ProjectVR.WebAPI.Contracts.Mapping.Request;

internal static class UpdateUserVrSetMappingExtension
{
    internal static Domain.Models.User.UpdateUserVrSet[] MapToDomain(this UpdateUserVrSet[] vrSets)
    {
        var domainVrSets = vrSets.Select(vs => new Domain.Models.User.UpdateUserVrSet
        {
            VrSetId = vs.VrSetId,
            IsFavorite = vs.IsFavorite
        }).ToArray();
        return domainVrSets;
    }
}