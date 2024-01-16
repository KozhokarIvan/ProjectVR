using System;
using System.Linq;
using ProjectVR.DataAccess.Entities;
using ProjectVR.Domain.Models;
using ProjectVR.Domain.Models.Enums;

namespace ProjectVR.DataAccess.Mapping;

internal static class UserSummaryMappingExtension
{
    public static UserSummary MapToDomain(this UserInfo userinfoEntity, Guid? ignoredUserGuid = null)
    {
        var userinfo = new UserSummary
        {
            Guid = userinfoEntity.Guid,
            Username = userinfoEntity.Username,
            Avatar = userinfoEntity.Avatar,
            CreatedAt = userinfoEntity.CreatedAt,
            LastSeen = userinfoEntity.LastSeen,
            Games = userinfoEntity.Games.Select(game => game.MapToDomain()).ToArray(),
            VrSets = userinfoEntity.VrSets.Select(vrSet => vrSet.MapToDomain()).ToArray(),
            FriendStatus = ignoredUserGuid.HasValue ? FriendStatus.Undefined : FriendStatus.Unauthorized
        };
        if (!ignoredUserGuid.HasValue)
            return userinfo;
        var request = userinfoEntity.Friends.FirstOrDefault(f
            => f.ToUserGuid == ignoredUserGuid || f.FromUserGuid == ignoredUserGuid);
        if (request is null)
            userinfo.FriendStatus = FriendStatus.Stranger;
        else if (ignoredUserGuid == userinfo.Guid) userinfo.FriendStatus = FriendStatus.Self;
        else if (request.AcceptedAt is not null) userinfo.FriendStatus = FriendStatus.Friend;
        else if (request.ToUserGuid == ignoredUserGuid) userinfo.FriendStatus = FriendStatus.Incoming;
        else if (request.FromUserGuid == ignoredUserGuid) userinfo.FriendStatus = FriendStatus.Outgoing;
        else userinfo.FriendStatus = FriendStatus.Undefined;
        return userinfo;
    }
}