using System.Linq;
using ProjectVR.Domain.Models;
using ProjectVR.Domain.Models.User;
using ProjectVR.WebAPI.Contracts.Mapping.Enums;
using ProjectVR.WebAPI.Contracts.Responses;

namespace ProjectVR.WebAPI.Contracts.Mapping.Responses;

internal static class GetUsersResponseMappingExtension
{
    internal static GetUsersResponse MapToApi(this UserSummary domainEntity)
    {
        var getUsersResponse = new GetUsersResponse
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