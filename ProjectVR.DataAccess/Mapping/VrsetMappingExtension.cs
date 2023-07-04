using ProjectVR.DataAccess.Models;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class VrsetMappingExtension
    {
        public static Domain.Entities.VrSet MapToDomainEntity(this VrSet vrset)
        {
            Domain.Entities.VrSet vrsetEntity = new Domain.Entities.VrSet
            {
                Id = vrset.Id,
                Name = vrset.Name
            };
            return vrsetEntity;
        }
    }
}
