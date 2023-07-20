using ProjectVR.DataAccess.Entities;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class VrsetMappingExtension
    {
        public static Domain.Models.VrSet MapToDomainModel(this VrSet vrset)
        {
            Domain.Models.VrSet vrsetEntity = new Domain.Models.VrSet
            {
                Id = vrset.Id,
                Name = vrset.Name,
                Icon = vrset.Icon
            };
            return vrsetEntity;
        }
    }
}
