using System.Linq;
using ProjectVR.Domain.Models;
using ProjectVR.WebAPI.Contracts.Responses;

namespace ProjectVR.WebAPI.Contracts.Mapping.Responses
{
    internal static class UsersSearchResponseMappingExtension
    {
        internal static UsersSearchResponse MapToSearchResponse(this UserSummary domainEntity)
        {
            UsersSearchResponse usersSearchResponse = new UsersSearchResponse
            {
                Guid = domainEntity.Guid,
                Username = domainEntity.Username,
                Avatar = domainEntity.Avatar,
                Games = domainEntity.Games.Select(game => game.MapToApi()).ToArray(),
                VrSets = domainEntity.VrSets.Select(vrset => vrset.MapToApi()).ToArray()
            };
            return usersSearchResponse;
        }
    }
}
