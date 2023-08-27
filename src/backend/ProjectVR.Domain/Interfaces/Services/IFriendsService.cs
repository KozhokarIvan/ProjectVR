using System;
using System.Threading.Tasks;

namespace ProjectVR.Domain.Interfaces.Services
{
    public interface IFriendsService
    {
        Task<bool> SendFriendRequest(Guid userGuid, Guid friendUserGuid);
        Task<bool> AcceptFriendRequest(Guid userGuid, Guid friendUserGuid);
        Task<bool> DeclineFriendRequest(Guid firstUserGuid, Guid secondUserGuid);
        Task<bool> DeleteFriend(Guid userGuid, Guid deletedFriendUserGuid);
    }
}
