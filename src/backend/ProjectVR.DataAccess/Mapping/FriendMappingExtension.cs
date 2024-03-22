using ProjectVR.DataAccess.Entities;
using ProjectVR.Domain.Models;

namespace ProjectVR.DataAccess.Mapping;

internal static class FriendMappingExtension
{
    internal static Friend MapToDomain(this Request requestEntity)
    {
        return new Friend
        {
            Id = requestEntity.Id,
            SenderUserGuid = requestEntity.FromUserGuid,
            AccepterUserGuid = requestEntity.ToUserGuid
        };
    }
}