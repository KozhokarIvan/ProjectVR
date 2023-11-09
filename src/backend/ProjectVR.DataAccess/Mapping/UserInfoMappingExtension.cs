using System.Linq;
using ProjectVR.DataAccess.Entities;
using ProjectVR.Domain.Models;

namespace ProjectVR.DataAccess.Mapping;

internal static class UserInfoMappingExtension
{
    public static UserSummary MapToDomainModel(this UserInfo userinfoEntity)
    {
        var userinfo = new UserSummary
        {
            Guid = userinfoEntity.Guid,
            Username = userinfoEntity.Username,
            Avatar = userinfoEntity.Avatar,
            CreatedAt = userinfoEntity.CreatedAt,
            LastSeen = userinfoEntity.LastSeen,
            Games = userinfoEntity.Games.Select(game => game.MapToDomainModel()).ToArray(),
            VrSets = userinfoEntity.VrSets.Select(vrset => vrset.MapToDomainModel()).ToArray()
        };
        return userinfo;
    }
}