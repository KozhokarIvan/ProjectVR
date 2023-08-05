using System;
using System.Threading.Tasks;

namespace ProjectVR.Domain.Interfaces.Services
{
    public interface IFriendsService
    {
        public Task<bool> SendFriendRequest(Guid fromUserGuid, Guid toUserGuid);
        public Task<bool> AcceptFriendRequest(Guid fromUserGuid, Guid toUserGuid);
        public Task<bool> CancelFriendRequest(Guid fromUserGuid, Guid toUserGuid);
        public Task<bool> DeclineFriendRequest(Guid fromUserGuid, Guid toUserGuid);
        public Task<bool> DeleteFriend(Guid firstUserGuid, Guid secondUserGuid);
    }
}
