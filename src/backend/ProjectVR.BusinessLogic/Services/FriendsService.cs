using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Interfaces.Services;

namespace ProjectVR.BusinessLogic.Services
{
    public class FriendsService : IFriendsService
    {
        private readonly IFriendsRepository _friendsRepository;
        public FriendsService(IFriendsRepository friendsRepository, IUsersRepository usersRepository)
        {
            _friendsRepository = friendsRepository;
        }

        public async Task<bool> AcceptFriendRequest(Guid fromUserGuid, Guid toUserGuid)
        {
            var friendEntryId = await _friendsRepository.GetExactFriendEntryIdByUsersGuids(fromUserGuid, toUserGuid);
            if (!friendEntryId.HasValue)
                return false;
            var result = await _friendsRepository.AddFriendEntryDate(friendEntryId.Value, DateTimeOffset.Now);
            return result;
        }

        public async Task<bool> CancelFriendRequest(Guid fromUserGuid, Guid toUserGuid)
        {
            var friendEntryId = await _friendsRepository.GetExactFriendEntryIdByUsersGuids(fromUserGuid, toUserGuid);
            if (!friendEntryId.HasValue)
                return false;
            var result = await _friendsRepository.DeleteFriendEntry(friendEntryId.Value);
            return result;
        }

        public async Task<bool> DeclineFriendRequest(Guid fromUserGuid, Guid toUserGuid)
        {
            var friendEntryId = await _friendsRepository.GetExactFriendEntryIdByUsersGuids(fromUserGuid, toUserGuid);
            if (!friendEntryId.HasValue)
                return false;
            var result = await _friendsRepository.DeleteFriendEntry(friendEntryId.Value);
            return result;
        }

        public async Task<bool> DeleteFriend(Guid firstUserGuid, Guid secondUserGuid)
        {
            var friendEntryId = await _friendsRepository.GetFriendEntryByUserGuids(firstUserGuid, secondUserGuid);
            if (!friendEntryId.HasValue)
                return false;
            var result = await _friendsRepository.ClearFriendEntryDate(friendEntryId.Value);
            return result;
        }

        public async Task<bool> SendFriendRequest(Guid fromUserGuid, Guid toUserGuid)
        {
            var friendRequestFromId = await _friendsRepository.GetExactFriendEntryIdByUsersGuids(fromUserGuid, toUserGuid);
            if (friendRequestFromId.HasValue)
                return false;
            var friendRequestToId = await _friendsRepository.GetExactFriendEntryIdByUsersGuids(toUserGuid, fromUserGuid);
            if (friendRequestToId.HasValue)
                return false;
            await _friendsRepository.CreateFriendEntry(fromUserGuid, toUserGuid);
            return true;
        }
    }
}
