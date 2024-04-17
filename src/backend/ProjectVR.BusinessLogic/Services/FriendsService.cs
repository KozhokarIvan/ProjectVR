using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Interfaces.Services;

namespace ProjectVR.BusinessLogic.Services;

public class FriendsService : IFriendsService
{
    private readonly IRequestsRepository _requestsRepository;

    public FriendsService(IRequestsRepository requestsRepository)
    {
        _requestsRepository = requestsRepository;
    }

    public async Task<bool> SendFriendRequest(Guid userGuid, Guid friendUserGuid)
    {
        if (userGuid == friendUserGuid)
            return false;
        var friendRequest = await _requestsRepository.GetRequestByUserGuids(userGuid, friendUserGuid);
        if (friendRequest is not null)
            return false;
        await _requestsRepository.CreateRequest(userGuid, friendUserGuid);
        return true;
    }

    public async Task<bool> AcceptFriendRequest(Guid accepterUserGuid, Guid senderUserGuid)
    {
        var friend = await _requestsRepository.GetExactRequestByUsersGuids(senderUserGuid, accepterUserGuid);
        if (friend is null)
            return false;
        if (friend.SenderUserGuid == accepterUserGuid)
            return false;
        var result = await _requestsRepository.AddAcceptedAtDate(friend.Id, DateTimeOffset.Now);
        return result;
    }

    public async Task<bool> DeclineFriendRequest(Guid firstUserGuid, Guid secondUserGuid)
    {
        var friend = await _requestsRepository.GetRequestByUserGuids(firstUserGuid, secondUserGuid);
        if (friend is null)
            return false;
        var result = await _requestsRepository.DeleteRequest(friend.Id);
        return result;
    }

    public async Task<bool> DeleteFriend(Guid userGuid, Guid deletedFriendUserGuid)
    {
        var friend = await _requestsRepository.GetRequestByUserGuids(userGuid, deletedFriendUserGuid);
        if (friend is null)
            return false;
        if (friend.SenderUserGuid == userGuid)
        {
            var isDeleted = await _requestsRepository.DeleteRequest(friend.Id);
            if (!isDeleted)
                return false;
            await _requestsRepository.CreateRequest(deletedFriendUserGuid, userGuid);
            return true;
        }

        var result = await _requestsRepository.ClearAcceptedAtDate(friend.Id);
        return result;
    }
}