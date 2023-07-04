using System.Linq;
using ProjectVR.Domain.Entities;
using ProjectVR.WebAPI.Contracts.Responses;

namespace ProjectVR.WebAPI.Contracts.Mapping.Responses
{
    internal static class UsersSearchResponseMappingExtension
    {
        internal static UsersSearchResponse MapToDomainEntity(this UserInfo domainEntity)
        {
            UsersSearchResponse usersSearchResponse = new UsersSearchResponse
            {
                Guid = domainEntity.Guid,
                Username = domainEntity.Username,
                Avatar = domainEntity.Avatar,
                Games = domainEntity.Games.Select(game => game.MapToApiEntity()).ToArray(),
                VrSets = domainEntity.VrSets.Select(vrset => vrset.MapToApiEntity()).ToArray()
            };
            return usersSearchResponse;
        }
    }
}
