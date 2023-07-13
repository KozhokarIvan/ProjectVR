using System.Linq;
using ProjectVR.DataAccess.Models;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class UserInfoMappingExtension
    {
        public static Domain.Entities.UserInfo MapToDomainEntity(this UserInfo userinfo)
        {
            Domain.Entities.UserInfo userinfoEntity = new Domain.Entities.UserInfo
            {
                Guid = userinfo.Guid,
                Username = userinfo.Username,
                Avatar = userinfo.Avatar,
                CreatedAt = userinfo.CreatedAt,
                LastSeen = userinfo.LastSeen,
                Games = userinfo.Games.Select(game => game.MapToDomain()).ToList(),
                VrSets = userinfo.VrSets.Select(vrset => vrset.MapToDomain()).ToList()
            };
            return userinfoEntity;
        }
    }
}