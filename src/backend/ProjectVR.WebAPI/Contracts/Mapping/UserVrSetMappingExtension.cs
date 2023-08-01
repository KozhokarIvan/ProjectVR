namespace ProjectVR.WebAPI.Contracts.Mapping
{
    internal static class UserVrSetMappingExtension
    {
        internal static UserVrSet MapToApi(this Domain.Models.UserVrSet domainUserVrSet)
        {
            UserVrSet userVrSet = new UserVrSet
            {
                VrSetName = domainUserVrSet.VrSetName,
                IsFavorite = domainUserVrSet.IsFavorite,
                VrSetIcon = domainUserVrSet.VrSetIcon
            };
            return userVrSet;
        }
    }
}
