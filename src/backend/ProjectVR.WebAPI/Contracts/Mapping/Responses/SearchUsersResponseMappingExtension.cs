using System.Linq;
using ProjectVR.Domain.Models;
using ProjectVR.WebAPI.Contracts.Mapping.Enums;
using ProjectVR.WebAPI.Contracts.Responses;

namespace ProjectVR.WebAPI.Contracts.Mapping.Responses;

internal static class SearchUsersResponseMappingExtension
{
    internal static SearchUsersResponse MapToApi(this UserSummary domainEntity)
    {
        var getUsersResponse = new SearchUsersResponse
        {
            Guid = domainEntity.Guid,
            Username = domainEntity.Username,
            Avatar = domainEntity.Avatar,
            Games = domainEntity.Games.Select(game => game.MapToApi()).ToArray(),
            VrSets = domainEntity.VrSets.Select(vrset => vrset.MapToApi()).ToArray(),
            FriendStatus = domainEntity.FriendStatus.MapToResponse()
        };
        return getUsersResponse;
    }
}