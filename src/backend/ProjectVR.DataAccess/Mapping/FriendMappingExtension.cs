using ProjectVR.Domain.Models;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class FriendMappingExtension
    {
        internal static Friend MapToDomain(this Entities.Friend friendEntity)
            => new Friend
            {
                Id = friendEntity.Id,
                SenderUserGuid = friendEntity.FromUserGuid,
                AccepterUserGuid = friendEntity.ToUserGuid
            };
    }
}
