using ProjectVR.DataAccess.Models;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class UserVrSetMappingExtension
    {
        internal static Domain.Entities.UserVrSet MapToDomain(this UserVrSet userVrSet)
        {
            Domain.Entities.UserVrSet userVrSetEntity = new Domain.Entities.UserVrSet
            {
                VrSet = userVrSet.VrSet.MapToDomain(),
                IsFavorite = userVrSet.IsFavorite
            };
            return userVrSetEntity;
        }
    }
}
