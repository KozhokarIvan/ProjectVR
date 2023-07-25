
using ProjectVR.Domain.Models;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class FriendMappingExtension
    {
        internal static Friend MapToDomainModel(this Entities.Friend friendEntity, UserInfo from, UserInfo to)
        {
            Friend friend = new Friend()
            {
                Id = friendEntity.Id,
                From = from,
                To = to,
                AcceptedAt = friendEntity.AcceptedAt
            };
            return friend;
        }
    }
}
