using ProjectVR.DataAccess.Entities;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class UserVrSetMappingExtension
    {
        internal static Domain.Models.UserVrSet MapToDomainModel(this UserVrSet userVrSet)
        {
            Domain.Models.UserVrSet userVrSetEntity = new Domain.Models.UserVrSet
            {
                VrSet = userVrSet.VrSet.MapToDomainModel(),
                IsFavorite = userVrSet.IsFavorite
            };
            return userVrSetEntity;
        }
    }
}
