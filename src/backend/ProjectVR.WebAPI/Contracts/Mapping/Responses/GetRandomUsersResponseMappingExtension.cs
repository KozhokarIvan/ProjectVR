using System.Linq;
using ProjectVR.Domain.Models;
using ProjectVR.Domain.Models.User;
using ProjectVR.WebAPI.Contracts.Mapping.Enums;
using ProjectVR.WebAPI.Contracts.Responses;

namespace ProjectVR.WebAPI.Contracts.Mapping.Responses;

internal static class GetRandomUsersResponseMappingExtension
{
    internal static GetRandomUsersResponse MapToGetRandomUsersResponse(this UserSummary domainEntity)
    {
        var user = new GetRandomUsersResponse
        {
            Guid = domainEntity.Guid,
            Username = domainEntity.Username,
            Avatar = domainEntity.Avatar,
            Games = domainEntity.Games.Select(game => game.MapToApi()).ToArray(),
            VrSets = domainEntity.VrSets.Select(vrset => vrset.MapToApi()).ToArray(),
            FriendStatus = domainEntity.FriendStatus.MapToResponse()
        };
        return user;
    }
}