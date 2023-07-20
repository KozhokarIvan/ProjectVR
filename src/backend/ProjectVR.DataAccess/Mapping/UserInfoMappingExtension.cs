using System.Linq;
using ProjectVR.DataAccess.Entities;

namespace ProjectVR.DataAccess.Mapping
{
    internal static class UserInfoMappingExtension
    {
        public static Domain.Models.UserInfo MapToDomainModel(this UserInfo userinfo)
        {
            Domain.Models.UserInfo userinfoEntity = new Domain.Models.UserInfo
            {
                Guid = userinfo.Guid,
                Username = userinfo.Username,
                Avatar = userinfo.Avatar,
                CreatedAt = userinfo.CreatedAt,
                LastSeen = userinfo.LastSeen,
                Games = userinfo.Games.Select(game => game.MapToDomainModel()).ToList(),
                VrSets = userinfo.VrSets.Select(vrset => vrset.MapToDomainModel()).ToList()
            };
            return userinfoEntity;
        }
    }
}