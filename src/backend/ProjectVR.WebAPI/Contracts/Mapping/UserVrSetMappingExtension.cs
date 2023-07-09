namespace ProjectVR.WebAPI.Contracts.Mapping
{
    internal static class UserVrSetMappingExtension
    {
        internal static UserVrSet MapToApiEntity(this Domain.Entities.UserVrSet domainUserVrSet)
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
