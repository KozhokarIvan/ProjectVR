using ProjectVR.Domain.Models;

namespace ProjectVR.DataAccess.Mapping;

internal static class UserVrSetMappingExtension
{
    internal static UserVrSet MapToDomain(this Entities.UserVrSet userVrSet)
    {
        var userVrSetEntity = new UserVrSet
        {
            VrSetId = userVrSet.VrSetId,
            VrSetIcon = userVrSet.VrSet.Icon,
            VrSetName = userVrSet.VrSet.Name,
            IsFavorite = userVrSet.IsFavorite
        };
        return userVrSetEntity;
    }
}