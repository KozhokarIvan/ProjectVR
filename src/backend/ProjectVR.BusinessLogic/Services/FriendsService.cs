using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Interfaces.Services;

namespace ProjectVR.BusinessLogic.Services;

public class FriendsService : IFriendsService
{
    private readonly IFriendsRepository _friendsRepository;

    public FriendsService(IFriendsRepository friendsRepository)
    {
        _friendsRepository = friendsRepository;
    }

    public async Task<bool> SendFriendRequest(Guid userGuid, Guid friendUserGuid)
    {
        if (userGuid == friendUserGuid)
            return false;
        var friendRequest = await _friendsRepository.GetFriendEntryByUserGuids(userGuid, friendUserGuid);
        if (friendRequest is not null)
            return false;
        await _friendsRepository.CreateFriendEntry(userGuid, friendUserGuid);
        return true;
    }

    public async Task<bool> AcceptFriendRequest(Guid accepterUserGuid, Guid senderUserGuid)
    {
        var friend = await _friendsRepository.GetExactFriendEntryByUsersGuids(senderUserGuid, accepterUserGuid);
        if (friend is null)
            return false;
        if (friend.SenderUserGuid == accepterUserGuid)
            return false;
        var result = await _friendsRepository.AddAcceptedAtDate(friend.Id, DateTimeOffset.Now);
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
        if (friend.SenderUserGuid == userGuid)
        {
            var isDeleted = await _friendsRepository.DeleteFriendEntry(friend.Id);
            if (!isDeleted)
                return false;
            await _friendsRepository.CreateFriendEntry(deletedUserGuid, userGuid);
            return true;
        }

        var result = await _friendsRepository.ClearAcceptedAtDate(friend.Id);
        return result;
    }
}