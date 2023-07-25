using ProjectVR.Domain.Models;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class FriendRequestMappingExtension
    {
        internal static FriendRequest MapToDomainModel(this Entities.FriendRequest friendRequestEntity, UserInfo from, UserInfo to)
        {
            FriendRequest friendRequest = new FriendRequest()
            {
                Id = friendRequestEntity.Id,
                From = from,
                To = to,
                SentAt = friendRequestEntity.SentAt
            };
            return friendRequest;
        }
    }
}
