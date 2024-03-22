using System.Linq;
using ProjectVR.Domain.Models.User;
using ProjectVR.WebAPI.Contracts.Mapping.Enums;
using ProjectVR.WebAPI.Contracts.Responses;

namespace ProjectVR.WebAPI.Contracts.Mapping.Responses;

internal static class GetDetailedUserInfoResponseMappingExtension
{
    internal static GetDetailedUserInfoResponse MapToApi(this UserDetails domainUser)
    {
        var user = new GetDetailedUserInfoResponse
        {
            Guid = domainUser.Guid,
            Username = domainUser.Username,
            Avatar = domainUser.Avatar,
            Games = domainUser.Games.Select(game => game.MapToApi()).ToArray(),
            VrSets = domainUser.VrSets.Select(vrset => vrset.MapToApi()).ToArray(),
            Friends = domainUser.Friends.Select(f => new UserPreview
            {
                Guid = f.Guid,
                Username = f.Username,
                Avatar = f.Avatar,
                FriendStatus = f.FriendStatus.MapToResponse()
            }).ToArray(),
            CreatedAt = domainUser.CreatedAt,
            LastSeen = domainUser.LastSeen,
            FriendStatus = domainUser.FriendStatus.MapToResponse()
        };
        return user;
    }
}