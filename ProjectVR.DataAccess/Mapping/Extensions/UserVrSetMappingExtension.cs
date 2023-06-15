using ProjectVR.DataAccess.Models;

namespace ProjectVR.DataAccess.Mapping.Extensions
{
    internal static class UserVrSetMappingExtension
    {
        internal static Domain.Entities.UserVrSet MapToDomainEntity(this UserVrSet userVrSet)
        {
            Domain.Entities.UserVrSet userVrSetEntity = new Domain.Entities.UserVrSet
            {
                VrSet = userVrSet.VrSet.MapToDomainEntity(),
                IsFavorite = userVrSet.IsFavorite
            };
            return userVrSetEntity;
        }
    }
}
