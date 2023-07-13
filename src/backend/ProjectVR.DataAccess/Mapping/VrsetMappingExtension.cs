using ProjectVR.DataAccess.Models;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class VrsetMappingExtension
    {
        public static Domain.Entities.VrSet MapToDomain(this VrSet vrset)
        {
            Domain.Entities.VrSet vrsetEntity = new Domain.Entities.VrSet
            {
                Id = vrset.Id,
                Name = vrset.Name,
                Icon = vrset.Icon
            };
            return vrsetEntity;
        }
    }
}
