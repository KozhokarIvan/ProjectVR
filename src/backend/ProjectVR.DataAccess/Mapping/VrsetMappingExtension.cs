using ProjectVR.Domain.Models;

namespace ProjectVR.DataAccess.Mapping;

internal static class VrsetMappingExtension
{
    public static VrSet MapToDomain(this Entities.VrSet vrset)
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