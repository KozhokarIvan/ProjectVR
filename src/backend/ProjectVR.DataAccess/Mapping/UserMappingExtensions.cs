using System;
using System.Linq;
using ProjectVR.DataAccess.Entities;
using ProjectVR.Domain.Models.Enums;
using ProjectVR.Domain.Models.User;

namespace ProjectVR.DataAccess.Mapping;

internal static class UserMappingExtensions
{
    internal static UserPreview MapToDomainUserBase(this UserInfo userinfoEntity, Guid? ignoredUserGuid = null)
    {
        var userinfo = UserPreview.Create(
            userinfoEntity.Guid,
            userinfoEntity.Username,
            userinfoEntity.Avatar,
            ignoredUserGuid.HasValue ? userinfoEntity.GetFriendStatus(ignoredUserGuid) : FriendStatus.Unauthorized
        );
        return userinfo;
    }

    internal static UserSummary MapToDomainUserSummary(this UserInfo userinfoEntity, Guid? ignoredUserGuid = null)
    {
        var userinfo = UserSummary.Create(
            userinfoEntity.Guid,
            userinfoEntity.Username,
            userinfoEntity.Avatar,
            ignoredUserGuid.HasValue ? userinfoEntity.GetFriendStatus(ignoredUserGuid) : FriendStatus.Unauthorized,
            userinfoEntity.Games.Select(game => game.MapToDomain()).ToArray(),
            userinfoEntity.VrSets.Select(vrSet => vrSet.MapToDomain()).ToArray()
        );
        return userinfo;
    }

    internal static UserDetails MapToDomainUserDetails(this UserInfo userinfoEntity, Guid? ignoredUserGuid = null)
    {
        var userDetails = UserDetails.Create(
            userinfoEntity.Guid,
            userinfoEntity.Username,
            userinfoEntity.Avatar,
            ignoredUserGuid.HasValue ? userinfoEntity.GetFriendStatus(ignoredUserGuid) : FriendStatus.Unauthorized,
            userinfoEntity.Games.Select(game => game.MapToDomain()).ToArray(),
            userinfoEntity.VrSets.Select(vrSet => vrSet.MapToDomain()).ToArray(),
            userinfoEntity.IncludeOnlyFriends(),
            userinfoEntity.CreatedAt,
            userinfoEntity.LastSeen
        );
        return userDetails;
    }

    private static FriendStatus GetFriendStatus(this UserInfo userinfoEntity, Guid? ignoredUserGuid)
    {
        if (userinfoEntity.Guid == ignoredUserGuid) return FriendStatus.Self;
        var request =
            userinfoEntity.OutgoingRequests.FirstOrDefault(f
                => f.ToUserGuid == ignoredUserGuid)
            ??
            userinfoEntity.IncomingRequests.FirstOrDefault(f
                => f.FromUserGuid == ignoredUserGuid);
        if (request is null)
            return FriendStatus.Stranger;
        if (request.AcceptedAt is not null) return FriendStatus.Friend;
        if (request.ToUserGuid == ignoredUserGuid) return FriendStatus.Incoming;
        if (request.FromUserGuid == ignoredUserGuid) return FriendStatus.Outgoing;
        return FriendStatus.Undefined;
    }

    private static UserPreview[] IncludeOnlyFriends(this UserInfo userinfoEntity)
    {
        return userinfoEntity.IncomingRequests
            .Select(r => UserPreview.Create(
                r.From.Guid,
                r.From.Username,
                r.From.Avatar,
                r.From.GetFriendStatus(userinfoEntity.Guid))
            ).Where(r => r.FriendStatus != FriendStatus.Incoming && r.FriendStatus != FriendStatus.Outgoing)
            .Concat(userinfoEntity.OutgoingRequests.Select(
                    r => UserPreview.Create(
                        r.To.Guid,
                        r.To.Username,
                        r.To.Avatar,
                        r.To.GetFriendStatus(userinfoEntity.Guid)
                    ))
                .Where(r => r.FriendStatus != FriendStatus.Incoming && r.FriendStatus != FriendStatus.Outgoing))
            .ToArray();
    }
}