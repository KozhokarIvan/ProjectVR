using ProjectVR.Domain.Models.VrSet;

namespace ProjectVR.DataAccess.Mapping;

internal static class VrSetMappingExtension
{
    internal static VrSet MapToDomain(this Entities.VrSet vrset)
    {
        var vrsetEntity = new VrSet
        {
            Id = vrset.Id,
            Name = vrset.Name,
            Icon = vrset.Icon
        };
        return vrsetEntity;
    }
}