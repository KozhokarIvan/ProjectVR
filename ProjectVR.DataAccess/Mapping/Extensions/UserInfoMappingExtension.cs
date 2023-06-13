using System.Linq;
using ProjectVR.DataAccess.Models;

namespace ProjectVR.DataAccess.Mapping.Extensions
{
    internal static class UserInfoMappingExtension
    {
        public static Domain.Entities.Userinfo MapToDomainEntity(this UserInfo userinfo)
        {
            Domain.Entities.Userinfo userinfoEntity = new Domain.Entities.Userinfo
            {
                Guid = userinfo.Guid,
                Username = userinfo.Username,
                Avatar = userinfo.Avatar,
                CreatedAt = userinfo.CreatedAt,
                LastSeen = userinfo.LastSeen,
                Games = userinfo.Games.Select(game => game.MapToDomainEntity()).ToList(),
                VrSets = userinfo.Vrsets.Select(vrset => vrset.MapToDomainEntity()).ToList()
            };
            return userinfoEntity;
        }
    }
}