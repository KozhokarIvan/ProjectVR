using System;
using System.Collections.Generic;
using System.Linq;
using ProjectVR.DataAccess.Entities;
using ProjectVR.Domain.Models;
using ProjectVR.Domain.Models.Enums;
using ProjectVR.DataAccess.Entities;

namespace ProjectVR.DataAccess.Mapping;

internal static class UserSummaryMappingExtension
{
    internal static UserBase MapToDomainUserBase(this UserInfo userinfoEntity, Guid? ignoredUserGuid = null)
    {
        var userinfo = new UserSummary
        {
            Guid = userinfoEntity.Guid,
            Username = userinfoEntity.Username,
            Avatar = userinfoEntity.Avatar,
            FriendStatus = ignoredUserGuid.HasValue ? FriendStatus.Undefined : FriendStatus.Unauthorized
        };
        if (!ignoredUserGuid.HasValue)
            return userinfo;
        userinfo.FriendStatus = userinfoEntity.GetFriendStatus(ignoredUserGuid);
        return userinfo;
    }

    internal static UserSummary MapToDomainUserSummary(this UserInfo userinfoEntity, Guid? ignoredUserGuid = null)
    {
        var userBase = userinfoEntity.MapToDomainUserBase(ignoredUserGuid);

        var userinfo = new UserSummary
        {
            Guid = userBase.Guid,
            Username = userBase.Username,
            Avatar = userBase.Avatar,
            FriendStatus = userBase.FriendStatus,
            Games = userinfoEntity.Games.Select(game => game.MapToDomain()).ToArray(),
            VrSets = userinfoEntity.VrSets.Select(vrSet => vrSet.MapToDomain()).ToArray(),
        };
        return userinfo;
    }

    internal static UserDetails MapToDomainUserDetails(this UserInfo userinfoEntity, Guid? ignoredUserGuid = null)
    {
        var userSummary = userinfoEntity.MapToDomainUserSummary(ignoredUserGuid);
        var userDetails = new UserDetails
        {
            Guid = userSummary.Guid,
            Username = userSummary.Username,
            Avatar = userSummary.Avatar,
            FriendStatus = userSummary.FriendStatus,
            Games = userSummary.Games,
            VrSets = userSummary.VrSets,
            Friends = userinfoEntity.IncludeOnlyFriends(),
            CreatedAt = userinfoEntity.CreatedAt,
            LastSeen = userinfoEntity.LastSeen
        };
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

    private static UserBase[] IncludeOnlyFriends(this UserInfo userinfoEntity)
    {
        return userinfoEntity.IncomingRequests
            .Select(r => new UserBase
            {
                Guid = r.From.Guid,
                Username = r.From.Username,
                Avatar = r.From.Avatar,
                FriendStatus = r.From.GetFriendStatus(userinfoEntity.Guid)
            }).Where(r => r.FriendStatus != FriendStatus.Incoming && r.FriendStatus != FriendStatus.Outgoing)
            .Concat(userinfoEntity.OutgoingRequests.Select(
                    r => new UserBase
                    {
                        Guid = r.To.Guid,
                        Username = r.To.Username,
                        Avatar = r.To.Avatar,
                        FriendStatus = r.To.GetFriendStatus(userinfoEntity.Guid)
                    })
                .Where(r => r.FriendStatus != FriendStatus.Incoming && r.FriendStatus != FriendStatus.Outgoing))
            .ToArray();
        
    }
}