using ProjectVR.DataAccess.Entities;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class UserVrSetMappingExtension
    {
        internal static Domain.Models.UserVrSet MapToDomainModel(this UserVrSet userVrSet)
        {
            Domain.Models.UserVrSet userVrSetEntity = new Domain.Models.UserVrSet
            {
                VrSetId = userVrSet.VrSetId,
                VrSetIcon = userVrSet.VrSet.Icon,
                VrSetName = userVrSet.VrSet.Name,
                IsFavorite = userVrSet.IsFavorite
            };
            return userVrSetEntity;
        }
    }
}
