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
        public async Task<bool> SendFriendRequest(Guid userGuid, Guid friendUserGuid)
        {
            var friendRequestFrom = await _friendsRepository.GetExactFriendEntryByUsersGuids(userGuid, friendUserGuid);
            if (friendRequestFrom is not null)
                return false;
            var friendRequestTo = await _friendsRepository.GetExactFriendEntryByUsersGuids(friendUserGuid, userGuid);
            if (friendRequestTo is not null)
                return false;
            await _friendsRepository.CreateFriendEntry(userGuid, friendUserGuid);
            return true;
        }

        public async Task<bool> AcceptFriendRequest(Guid userGuid, Guid friendUserGuid)
        {
            var friend = await _friendsRepository.GetExactFriendEntryByUsersGuids(userGuid, friendUserGuid);
            if (friend is null)
                return false;
            var result = await _friendsRepository.AddFriendEntryDate(friend.Id, DateTimeOffset.Now);
            return result;
        }

        public async Task<bool> DeclineFriendRequest(Guid firstUserGuid, Guid secondUserGuid)
        {
            var friend = await _friendsRepository.GetFriendEntryByUserGuids(firstUserGuid, secondUserGuid);
            if (friend is null)
                return false;
            var result = await _friendsRepository.DeleteFriendEntry(friend.Id);
            return result;
        }

        public async Task<bool> DeleteFriend(Guid userGuid, Guid deletedUserGuid)
        {
            var friend = await _friendsRepository.GetFriendEntryByUserGuids(userGuid, deletedUserGuid);
            if (friend is null)
                return false;
            if (friend.FromUserGuid == userGuid)
            {
                var isDeleted = await _friendsRepository.DeleteFriendEntry(friend.Id);
                if (!isDeleted)
                    return false;
                await _friendsRepository.CreateFriendEntry(deletedUserGuid, userGuid);
                return true;
            }
            else
            {
                var result = await _friendsRepository.ClearFriendEntryDate(friend.Id);
                return result;
            }
        }
    }
}
