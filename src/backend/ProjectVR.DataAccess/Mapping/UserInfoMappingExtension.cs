using System.Linq;
using ProjectVR.Domain.Models;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class UserInfoMappingExtension
    {
        public static UserInfo MapToDomainModel(this Entities.UserInfo userinfoEntity)
        {
            UserInfo userinfo = userinfoEntity.MapToDomainModelWithoutFriendsInfo();
            userinfo.OutgoingRequests = userinfoEntity.OutgoingFriendRequests
                .Select(r => 
                    r.MapToDomainModel(r.From.MapToDomainModelWithoutFriendsInfo(), r.To.MapToDomainModelWithoutFriendsInfo()))
                .ToArray();

            userinfo.IncomingRequests = userinfoEntity.IncomingFriendRequests
                .Select(r => 
                    r.MapToDomainModel(r.From.MapToDomainModelWithoutFriendsInfo(), r.To.MapToDomainModelWithoutFriendsInfo()))
                .ToArray();

            userinfo.Friends = userinfoEntity.Friends
                .Select(f =>
                    f.MapToDomainModel(f.From.MapToDomainModelWithoutFriendsInfo(), f.To.MapToDomainModelWithoutFriendsInfo()))
                .ToArray();

            return userinfo;
        }
        public static UserInfo MapToDomainModelWithoutFriendsInfo(this Entities.UserInfo userinfoEntity)
        {
            UserInfo userinfo = new UserInfo
            {
                Guid = userinfoEntity.Guid,
                Username = userinfoEntity.Username,
                Avatar = userinfoEntity.Avatar,
                CreatedAt = userinfoEntity.CreatedAt,
                LastSeen = userinfoEntity.LastSeen,
                Games = userinfoEntity.Games.Select(game => game.MapToDomainModel()).ToArray(),
                VrSets = userinfoEntity.VrSets.Select(vrset => vrset.MapToDomainModel()).ToArray(),
            };
            return userinfo;
        }
    }
}