namespace ProjectVR.WebAPI.Contracts.Mapping;

internal static class UserVrSetMappingExtension
{
    internal static UserVrSet MapToApi(this Domain.Models.UserVrSet domainUserVrSet)
    {
        var userVrSet = new UserVrSet
        {
            VrSetId = domainUserVrSet.VrSetId,
            VrSetName = domainUserVrSet.VrSetName,
            IsFavorite = domainUserVrSet.IsFavorite,
            VrSetIcon = domainUserVrSet.VrSetIcon
        };
        return userVrSet;
    }
}