namespace ProjectVR.WebAPI.Contracts.Mapping
{
    internal static class UserVrSetMappingExtension
    {
        internal static UserVrSet MapToApi(this Domain.Models.UserVrSet domainUserVrSet)
        {
            UserVrSet userVrSet = new UserVrSet
            {
                VrSetId = domainUserVrSet.VrSet.Id,
                Name = domainUserVrSet.VrSet.Name,
                IsFavorite = domainUserVrSet.IsFavorite,
                Icon = domainUserVrSet.VrSet.Icon
            };
            return userVrSet;
        }
    }
}
